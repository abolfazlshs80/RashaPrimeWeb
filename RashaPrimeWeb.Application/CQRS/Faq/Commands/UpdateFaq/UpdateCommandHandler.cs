using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Faq.Commands.UpdateFaq;
//[FromKeyedServices("EF")] IFaqRepository repFaq
public class UpdateFaqCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateFaqCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(UpdateFaqCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Faq>();

            var Faq = await currentRep.GetByIdAsync(request.Id);



            Faq.Email = request.Email;
            Faq.FullName = request.FullName;
            Faq.Phone = request.Phone;
            Faq.ReplayText = request.ReplayText;
            Faq.Text = request.Text;
            Faq.Lang_Id = request.Lang_Id;




            await currentRep.UpdateAsync(Faq);



            await unitOfWork.SaveChangesAsync();
            //order

            return Faq.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}