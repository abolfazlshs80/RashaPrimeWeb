using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Language.Commands.DeleteLanguage;
//[FromKeyedServices("EF")] ILanguageRepository repLanguage
public class DeleteLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteLanguageCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Language>();


            var GetLanguageById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetLanguageById != null)
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