namespace RashaPrimeWeb.Application.CQRS.Slider.Queries.GetAllSlider;

public class GetAllSliderDto 
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Text { get; set; }
    public string PathImage { get; set; }
    public int Order { get; set; }

    public int? Lang_Id { get; set; }

}
