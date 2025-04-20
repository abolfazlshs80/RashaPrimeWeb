using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.News.Commands.CreateNews;
//[FromKeyedServices("EF")] INewsRepository repNews
public class CreateNewsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateNewsCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateNewsCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.News>();

            var News = new Domain.Entities.News()
            {
                TitleBrowser = request.TitleBrowser,
                LinkKey = request.LinkKey,
                LongTitle = request.LongTitle,
                Text = request.Text,
                ShortTitle = request.ShortTitle,
                Lang_Id = request.Lang_Id,
                Seen = request.Seen,
                //IsDeleted = false,
                //Status = true
            };


            await currentRep.AddAsync(News);

            await unitOfWork.SaveChangesAsync();
            //order

            return News.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}