using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Service.Commands.DeleteNews;
//[FromKeyedServices("EF")] IServiceRepository repService
public class DeleteServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteServiceCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Service>();


            var GetServiceById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetServiceById != null)
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