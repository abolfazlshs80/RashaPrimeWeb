using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Tag.Commands.UpdateTag;
//[FromKeyedServices("EF")] ITagRepository repTag
public class UpdateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateTagCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(UpdateTagCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Tag>();

            var Tag = await currentRep.GetByIdAsync(request.Id);



            Tag.Name = request.Name;
        



            await currentRep.UpdateAsync(Tag);



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