using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Faq.Commands.CreateFaq;
//[FromKeyedServices("EF")] IFaqRepository repFaq
public class CreateFaqCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateFaqCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateFaqCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Faq>();

            var Faq = new Domain.Entities.Faq()
            {
                Email = request.Email,
                FullName = request.FullName,
                Phone = request.Phone,
                ReplayText = request.ReplayText,
                Text = request.Text,
                Lang_Id = request.Lang_Id,
            };


            await currentRep.AddAsync(Faq);

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