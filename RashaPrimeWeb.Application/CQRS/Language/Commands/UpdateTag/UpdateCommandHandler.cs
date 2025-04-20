using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Language.Commands.UpdateLanguage;
//[FromKeyedServices("EF")] ILanguageRepository repLanguage
public class UpdateLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateLanguageCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Language>();

            var Language = await currentRep.GetByIdAsync(request.Id);



            Language.Title = request.Title;
            Language.LanguageTitle = request.LanguageTitle;
        



            await currentRep.UpdateAsync(Language);



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