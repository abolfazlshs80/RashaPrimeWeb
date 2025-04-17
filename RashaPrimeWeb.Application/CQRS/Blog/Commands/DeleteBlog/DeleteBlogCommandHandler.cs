using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Blog.Commands.DeleteBlog;
//[FromKeyedServices("EF")] IBlogRepository repBlog
public class DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteBlogCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Blog>();


            var GetBlogById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetBlogById != null)
            {
                await currentRep.DeleteAsync(request.Id);
            }


            await unitOfWork.SaveChangesAsync();
            //order
            return request.Id;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e.Message);


        }

    }
}