namespace Kashi_Seramic.MVC.Models
{
	public class TableInfoAdminVM
	{
        public string Id { get; set; }
        public string ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }
        public bool Sugestion { get; set; }
        public List<TableLinkOption> TableLinkOptions { get; set; }
    }
}
