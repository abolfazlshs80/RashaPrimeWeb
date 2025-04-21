using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Slider.Commands.UpdateSlider;
//[FromKeyedServices("EF")] ISliderRepository repSlider
public class UpdateSliderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateSliderCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(UpdateSliderCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Slider>();

            var Slider = await currentRep.GetByIdAsync(request.Id);




            Slider.Title = request.Title;
            Slider.PathImage = request.PathImage;
            Slider.Order = request.Order;

            Slider.Text = request.Text;
            Slider.Lang_Id = request.Lang_Id;



            await currentRep.UpdateAsync(Slider);



            await unitOfWork.SaveChangesAsync();
            //order

            return Slider.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}