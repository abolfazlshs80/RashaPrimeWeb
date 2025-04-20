using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Language.Commands.CreateLanguage;
//[FromKeyedServices("EF")] ILanguageRepository repLanguage
public class CreateLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateLanguageCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateLanguageCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Language>();

            var Language = new Domain.Entities.Language()
            {
             Title = request.Title,
             LanguageTitle = request.LanguageTitle
            };


            await currentRep.AddAsync(Language);

            await unitOfWork.SaveChangesAsync();
            //order

            return Language.Lang_Id.Value;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}