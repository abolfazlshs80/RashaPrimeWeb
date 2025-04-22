using System.Collections.Generic;

namespace Kashi_Seramic.MVC.Models
{
    public class TableVM
    {
      public  List< TableInfoAdminVM> Tables {  get; set; }=new List<TableInfoAdminVM>() { };
      public List< TableLinkOption> Links {  get; set; }=new List<TableLinkOption>() { };
    }
}
