using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Slider.Queries.GetSlider;

public class GetSliderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetSliderQuery, GetSliderDto>
{



    public async Task<GetSliderDto> Handle(GetSliderQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repSlider = unitOfWork.Repository<Domain.Entities.Slider>();

        
        var LastSlider = await repSlider
            .GetByIdAsync(request.Id);
        var mappingSlider = new GetSliderDto();

        #region Mapping

        
       mappingSlider. Title = LastSlider.Title;
       mappingSlider. PathImage = LastSlider.PathImage;
       mappingSlider. Order = LastSlider.Order;
  
       mappingSlider. Text = LastSlider.Text;
        mappingSlider.Lang_Id = LastSlider.Lang_Id;


        mappingSlider.Id = LastSlider.Id;
 


        #endregion


        return mappingSlider;

    }

}