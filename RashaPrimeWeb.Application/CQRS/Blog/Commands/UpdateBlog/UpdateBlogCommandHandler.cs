using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace RashaPrimeWeb.Application.CQRS.Blog.Commands.UpdateBlog;
//[FromKeyedServices("EF")] IBlogRepository repBlog
public class UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateBlogCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Blog>();

            var Blog = await currentRep.GetByIdAsync(request.Id);



            Blog.TitleBrowser = request.TitleBrowser;
            Blog.LinkKey = request.LinkKey;
            Blog.LongTitle = request.LongTitle;
            Blog.ShortTitle = request.ShortTitle;
            Blog.Lang_Id = request.Lang_Id;
            Blog.Text = request.Text;
            Blog.Seen = request.Seen;



            await currentRep.UpdateAsync(Blog);



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