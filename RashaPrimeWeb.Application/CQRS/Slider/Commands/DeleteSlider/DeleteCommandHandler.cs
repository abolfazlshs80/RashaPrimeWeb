using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Slider.Commands.DeleteSlider;
//[FromKeyedServices("EF")] ISliderRepository repSlider
public class DeleteSliderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteSliderCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(DeleteSliderCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Slider>();


            var GetSliderById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetSliderById != null)
            {
                await currentRep.DeleteAsync(request.Id);
            }


            await unitOfWork.SaveChangesAsync();
            //order
            return request.Id;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e.Message);


        }

    }
}