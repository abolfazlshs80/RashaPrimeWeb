using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Tag.Queries.GetTag;

public class GetTagQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetTagQuery, GetTagDto>
{



    public async Task<GetTagDto> Handle(GetTagQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repTag = unitOfWork.Repository<Domain.Entities.Tag>();

        
        var LastTag = await repTag
            .GetByIdAsync(request.Id);
        var mappingTag = new GetTagDto();

        #region Mapping

        mappingTag.Name = LastTag.Name;
        mappingTag.Id = LastTag.Id;
 


        #endregion


        return mappingTag;

    }

}