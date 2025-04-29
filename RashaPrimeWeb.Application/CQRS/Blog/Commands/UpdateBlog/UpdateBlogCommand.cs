using MediatR;
using Microsoft.AspNetCore.Http;
using RashaPrimeWeb.Application.Models.Models;

namespace RashaPrimeWeb.Application.CQRS.Blog.Commands.UpdateBlog;

public record UpdateBlogCommand : BaseDTO, IRequest<ErrorOr<int>>
{

    public string TitleBrowser { get; set; }

    public int? Lang_Id { get; set; }
    public string ShortTitle { get; set; }

    public string LongTitle { get; set; }

    public string Text { get; set; }

    public int Seen { get; set; }

    public string LinkKey
    {
        get { return RandomExtention.GetShortLink(""); }
    }
    public List<int>? TagId { get; set; }

    public List<int>? CategoryId { get; set; }
    //public List<int> LanguageId { get; set; }
    public IFormFile? FileForDetials { get; set; }

    public IFormFile? FileHeader { get; set; }


}