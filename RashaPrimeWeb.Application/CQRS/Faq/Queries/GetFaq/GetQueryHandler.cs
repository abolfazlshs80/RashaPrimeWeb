using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Faq.Queries.GetFaq;

public class GetFaqQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetFaqQuery, GetFaqDto>
{



    public async Task<GetFaqDto> Handle(GetFaqQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repFaq = unitOfWork.Repository<Domain.Entities.Faq>();

        
        var LastFaq = await repFaq
            .GetByIdAsync(request.Id);
        var mappingFaq = new GetFaqDto();

        #region Mapping

        mappingFaq.Email = LastFaq.Email;
        mappingFaq.FullName = LastFaq.FullName;
        mappingFaq.Phone = LastFaq.Phone;
        mappingFaq.ReplayText = LastFaq.ReplayText;
        mappingFaq.Text = LastFaq.Text;
        mappingFaq.Lang_Id = LastFaq.Lang_Id;
        mappingFaq.Id = LastFaq.Id;
 


        #endregion


        return mappingFaq;

    }

}