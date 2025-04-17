using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Blog.Queries.GetBlog;

public class GetBlogQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetBlogQuery, GetBlogDto>
{



    public async Task<GetBlogDto> Handle(GetBlogQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repBlog = unitOfWork.Repository<Domain.Entities.Blog>();

        
        var LastBlog = await repBlog
            .GetByIdAsync(request.Id);
        var mappingBlog = new GetBlogDto();

        #region Mapping

        mappingBlog.TitleBrowser = LastBlog.TitleBrowser;
        mappingBlog.LinkKey = LastBlog.LinkKey;
        mappingBlog.LongTitle = LastBlog.LongTitle;
        mappingBlog.ShortTitle = LastBlog.ShortTitle;
        mappingBlog.Lang_Id = LastBlog.Lang_Id;
        mappingBlog.Seen = LastBlog.Seen;


        #endregion


        return mappingBlog;

    }

}