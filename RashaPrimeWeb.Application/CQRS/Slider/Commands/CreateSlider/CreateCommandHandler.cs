using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Slider.Commands.CreateSlider;
//[FromKeyedServices("EF")] ISliderRepository repSlider
public class CreateSliderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateSliderCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateSliderCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Slider>();

            var Slider = new Domain.Entities.Slider()
            {
                Title = request.Title,
                PathImage = request.PathImage,
                Order = request.Order,
  
                Text = request.Text,
                Lang_Id = request.Lang_Id,
            };


            await currentRep.AddAsync(Slider);

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