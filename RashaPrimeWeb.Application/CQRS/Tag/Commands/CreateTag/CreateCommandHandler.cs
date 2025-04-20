using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Tag.Commands.CreateTag;
//[FromKeyedServices("EF")] ITagRepository repTag
public class CreateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateTagCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateTagCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Tag>();

            var Tag = new Domain.Entities.Tag()
            {
             Name = request.Name
            };


            await currentRep.AddAsync(Tag);

            await unitOfWork.SaveChangesAsync();
            //order

            return Tag.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}