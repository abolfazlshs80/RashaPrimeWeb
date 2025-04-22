using AutoMapper;
using MediatR;
using RashaPrimeWeb.Application.Contracts.Infrastructure;
using RashaPrimeWeb.Domain.Entities;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Blog.Commands.CreateBlog;
//[FromKeyedServices("EF")] IBlogRepository repBlog
public class CreateBlogCommandHandler(IUnitOfWork unitOfWork, IFileUploaderService fileUploaderService, IMapper mapper)
    : IRequestHandler<CreateBlogCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateBlogCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Blog>();
            var categoryRep = unitOfWork.Repository<Domain.Entities.CategoryToBlog>();
            var tagRep = unitOfWork.Repository<Domain.Entities.TagToBlog>();
            var fileRep = unitOfWork.Repository<Domain.Entities.FileManager>();
            var fileToBlogRep = unitOfWork.Repository<Domain.Entities.FileToBlog>();

            var Blog = new Domain.Entities.Blog()
            {
                TitleBrowser = request.TitleBrowser,
                LinkKey = request.LinkKey,
                LongTitle = request.LongTitle,
                Text = request.Text,
                ShortTitle = request.ShortTitle,
                Lang_Id = request.Lang_Id,
                Seen = request.Seen,
                //IsDeleted = false,
                //Status = true
            };

            var resBlog = await currentRep.AddAsync(Blog, cancellationToken);
            await unitOfWork.SaveChangesAsync();
            var BlogId = Blog.Id;

            foreach (var item in request.CategoryId)
            {
                await categoryRep.AddAsync(
                            new CategoryToBlog()
                            {
                                BlogId = BlogId,
                                CategoryId = item
                            });
            }

            await unitOfWork.SaveChangesAsync();

            foreach (var item in request.TagId ?? Enumerable.Empty<int>())
            {
                var resTag = tagRep.AddAsync(new TagToBlog()
                { BlogId = BlogId, TagId = item });
            }
            await unitOfWork.SaveChangesAsync();
            #region File

            if (request.FileForDetials == null || request.FileHeader == null)
            {
                return 0;
            }

            #endregion


            var filename = request.TitleBrowser.Replace(" ", "-");
            var rnd = new Random().Next(1000, 99999).ToString();
            var Name = await fileUploaderService.UpdloadFile(request.FileHeader, "Blog", filename + rnd);
            var resBlogSlider = await fileRep.AddAsync(new FileManager()
            {


                IsUploaderFile = false,
                Title = request.TitleBrowser,
                Path = Name,
                Type = "Blog"
            });
            await unitOfWork.SaveChangesAsync();
            var filetoblog = await fileToBlogRep.AddAsync(new FileToBlog()
            {
                BlogId = BlogId,
                ImageId = resBlogSlider.Id
            });

            Name = await fileUploaderService.UpdloadFile(request.FileHeader, "Blog", filename + rnd + "-BG");


            await unitOfWork.SaveChangesAsync();


            return Blog.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}