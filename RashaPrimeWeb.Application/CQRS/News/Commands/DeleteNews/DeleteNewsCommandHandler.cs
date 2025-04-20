using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.News.Commands.DeleteNews;
//[FromKeyedServices("EF")] INewsRepository repNews
public class DeleteNewsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteNewsCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(DeleteNewsCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.News>();


            var GetNewsById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetNewsById != null)
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