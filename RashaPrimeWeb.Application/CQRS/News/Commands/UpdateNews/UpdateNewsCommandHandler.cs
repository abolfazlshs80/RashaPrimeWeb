using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.News.Commands.UpdateNews;
//[FromKeyedServices("EF")] INewsRepository repNews
public class UpdateNewsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateNewsCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(UpdateNewsCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.News>();

            var News = await currentRep.GetByIdAsync(request.Id);



            News.TitleBrowser = request.TitleBrowser;
            News.LinkKey = request.LinkKey;
            News.LongTitle = request.LongTitle;
            News.ShortTitle = request.ShortTitle;
            News.Lang_Id = request.Lang_Id;
            News.Text = request.Text;
            News.Seen = request.Seen;



            await currentRep.UpdateAsync(News);



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