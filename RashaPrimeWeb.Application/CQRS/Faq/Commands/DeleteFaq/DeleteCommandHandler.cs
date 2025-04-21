using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Faq.Commands.DeleteFaq;
//[FromKeyedServices("EF")] IFaqRepository repFaq
public class DeleteFaqCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteFaqCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(DeleteFaqCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Faq>();


            var GetFaqById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetFaqById != null)
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