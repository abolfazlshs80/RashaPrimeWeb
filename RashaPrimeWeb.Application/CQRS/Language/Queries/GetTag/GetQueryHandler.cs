using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Language.Queries.GetLanguage;

public class GetLanguageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetLanguageQuery, GetLanguageDto>
{



    public async Task<GetLanguageDto> Handle(GetLanguageQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repLanguage = unitOfWork.Repository<Domain.Entities.Language>();

        
        var LastLanguage = await repLanguage
            .GetByIdAsync(request.Id);
        var mappingLanguage = new GetLanguageDto();

        #region Mapping

        mappingLanguage.Title = LastLanguage.Title;
        mappingLanguage.LanguageTitle = LastLanguage.LanguageTitle;
        mappingLanguage.Lang_Id = LastLanguage.Lang_Id;
 


        #endregion


        return mappingLanguage;

    }

}