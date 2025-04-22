namespace Kashi_Seramic.MVC.Models
{
	public class TableLinkOption
	{
		public TableLinkOption(string Link, string Icons, string Title)
		{

			this.Link = Link;
			this.Icons = Icons;
			this.Title = Title;
		}

		public string Link { get; set; }
		public string Icons { get; set; }
		public string Title { get; set; }
	}
}
