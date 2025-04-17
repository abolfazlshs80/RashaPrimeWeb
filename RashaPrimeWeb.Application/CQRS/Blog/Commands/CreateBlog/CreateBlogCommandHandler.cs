using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Blog.Commands.CreateBlog;
//[FromKeyedServices("EF")] IBlogRepository repBlog
public class CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateBlogCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateBlogCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Blog>();

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


            await currentRep.AddAsync(Blog);

            await unitOfWork.SaveChangesAsync();
            //order

            return Blog.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}