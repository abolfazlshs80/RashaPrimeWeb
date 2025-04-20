using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.News.Queries.GetNews;

public class GetNewsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetNewsQuery, GetNewsDto>
{



    public async Task<GetNewsDto> Handle(GetNewsQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repNews = unitOfWork.Repository<Domain.Entities.News>();

        
        var LastNews = await repNews
            .GetByIdAsync(request.Id);
        var mappingNews = new GetNewsDto();

        #region Mapping

        mappingNews.TitleBrowser = LastNews.TitleBrowser;
        mappingNews.LinkKey = LastNews.LinkKey;
        mappingNews.LongTitle = LastNews.LongTitle;
        mappingNews.ShortTitle = LastNews.ShortTitle;
        mappingNews.Lang_Id = LastNews.Lang_Id;
        mappingNews.Seen = LastNews.Seen;


        #endregion


        return mappingNews;

    }

}