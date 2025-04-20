using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Tag.Commands.DeleteTag;
//[FromKeyedServices("EF")] ITagRepository repTag
public class DeleteTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteTagCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(DeleteTagCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Tag>();


            var GetTagById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetTagById != null)
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