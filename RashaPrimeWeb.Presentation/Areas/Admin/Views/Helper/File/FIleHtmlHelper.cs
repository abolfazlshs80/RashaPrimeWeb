using Kashi_Seramic.MVC.Models;
using Microsoft.AspNetCore.Html;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.Text;


public static class CustomHtmlHelper
{
    public static IHtmlContent CustomFileHtmlHelper(this IHtmlHelper htmlHelper, string name, string text, bool multiple = false)
    {
        var value = multiple ? "multiple" : "";

        string myTag =
            ($"		<div class=\"card mt-3\"> <h5 class=\"card-header\">{text}</h5><div class=\"card-body\"><div class=\"dz-message needsclick\">Drop files here or click to upload<span class=\"note needsclick\">(This is just a demo dropzone. Selected files are <strong>not</strong> actually uploaded.)</span></div><div class=\"fallback\"><input name=\"{name}\" {multiple} type=\"file\" /></div></div></div>");

        return new HtmlString(myTag);
    }

    public static IHtmlContent CustomSubmitHtmlHelper(this IHtmlHelper htmlHelper)
    {

        string myTag = ($"<input type=\"submit\" class=\"btn btn-primary my-3\" value=\"ثبت\" />");

        return new HtmlString(myTag);
    }
    public static IHtmlContent CustomCancelSubmitHtmlHelper(this IHtmlHelper htmlHelper)
    {

        string myTag = ($"   <a onclick=\"history.back()\" class=\"btn btn-danger col-md-2 mt-3 mx-2\">انصراف</a>");

        return new HtmlString(myTag);
    }
    public static IHtmlContent CustomCkEditorHtmlHelper(this IHtmlHelper htmlHelper, string name, string value = "", string title = "")
    {

        string myTag = $"\r\n\t\t\t\t<br />\r\n\t\t\t\t<h5>{title}</h5><textarea name=\"{name}\" class=\"myTextarea w-75 mt-3\">{value}</textarea>";


        return new HtmlString(myTag);
    }


    public static IHtmlContent CustomHiddenHtmlHelper(this IHtmlHelper htmlHelper, string name, string value)
    {

        string myTag = $"         <input type=\"hidden\" name=\"{name}\" value=\"{value}\" />";


        return new HtmlString(myTag);
    }

    public static IHtmlContent CustomEditorHtmlHelper(this IHtmlHelper htmlHelper, string name, string placeholder, string value = "", bool isrequired = false)
    {
        string tagreq = isrequired ? "required=\"\"" : "";
        string myTag =
            $" <div class=\"form-group\"><label for=\"{name}\">{placeholder}</label>  <input {tagreq} class=\"form-control mb-4\" id=\"{name}\" name=\"{name}\" value=\"{value}\" placeholder=\"{placeholder} را وارد کنید...\" type=\"text\"><span class=\"field-validation-valid\" data-valmsg-for=\"{name}\" data-valmsg-replace=\"true\"></span></div>";


        return new HtmlString(myTag);
    }
    public static IHtmlContent CustomCheckBoxHtmlHelper(this IHtmlHelper htmlHelper, string name, string placeholder, bool IsChecked, string value = "")
    {
        var selected = IsChecked ? "checked" : "";
        var Con_Value = value.Equals("") ? "true" : value;
        string myTag =
            $"   <div class=\"col-lg-12 \"> <div class=\"form-group mt-2 d-flex justify-content-start\"><label for=\"{name}\">{placeholder}</label>        <input type=\"checkbox\" value=\"{Con_Value}\" {selected} name=\"{name}\"/><span class=\"field-validation-valid\" data-valmsg-for=\"{name}\" data-valmsg-replace=\"true\"></span></div></div>";


        return new HtmlString(myTag);
    }


    public static IHtmlContent CustomCkEditorScriptHtmlHelper(this IHtmlHelper htmlHelper)
    {

        string myTag =
            $" <script src=\"https://cdn.ckeditor.com/ckeditor5/39.0.0/super-build/ckeditor.js\"></script>\r\n\t<script src=\"https://cdn.ckeditor.com/ckeditor5/39.0.1/classic/ckeditor.js\"></script>\r\n\t<script src=\"https://cdn.ckeditor.com/ckeditor5/39.0.1/classic/translations/de.js\"></script>\r\n\t<script src=\"/AspAdmin/assets/js/CkEditor.js\"></script>";


        return new HtmlString(myTag);
    }

    public static IHtmlContent CustomUploadImageScriptHtmlHelper(this IHtmlHelper htmlHelper)
    {

        string myTag =
            $" \t<script src=\"/AspAdmin/assets/vendor/libs/dropzone/dropzone.js\"></script>\r\n\t<script src=\"/AspAdmin/assets/js/forms-file-upload.js\"></script>";


        return new HtmlString(myTag);
    }

    public static IHtmlContent CustomUploadImageLinkHtmlHelper(this IHtmlHelper htmlHelper)
    {

        string myTag =
            $"\t<link rel=\"stylesheet\" href=\"/AspAdmin/assets/vendor/css/rtl/core.css\" class=\"template-customizer-core-css\" />\r\n\t<link rel=\"stylesheet\" href=\"/AspAdmin/assets/vendor/libs/dropzone/dropzone.css\" />";


        return new HtmlString(myTag);
    }

    public static IHtmlContent CustomCkEditorLinkHtmlHelper(this IHtmlHelper htmlHelper)
    {

        string myTag = $" <link rel=\"stylesheet\" href=\"/AspAdmin/assets/css/CkEditor.css\" />";

        return new HtmlString(myTag);

    }


    public static IHtmlContent CustomModalDeleteHtmlHelper(this IHtmlHelper htmlHelper, string title, string desc, string ControllerName)
    {

        string myTag = $" <div class=\"modal fade\" id=\"modaldemo5\">\r\n    <div class=\"modal-dialog modal-dialog-centered text-center\" role=\"document\">\r\n        <div class=\"modal-content tx-size-sm\">\r\n            <div class=\"modal-body text-center p-4 pb-5\" id=\"modalbody\">\r\n                <button aria-label=\"Close\" class=\"btn-close position-absolute\" data-bs-dismiss=\"modal\"><span aria-hidden=\"true\">&times;</span></button>\r\n                <i class=\"icon icon-close fs-70 text-danger lh-1 my-5 d-inline-block\"></i>\r\n                <h4 class=\"text-danger\">{title}</h4>\r\n                <p class=\"mg-b-20 mg-x-20\">{desc}</p>\r\n\r\n         <form action=\"/Admin/{ControllerName}/Delete\" method=\"post\"> <input type=\"hidden\" name=\"Id\" id=\"Id\" value=\"\"/>  <button aria-label=\"Close\" type=\"submit\" class=\"btn btn-danger pd-x-25\" data-bs-dismiss=\"modal\">حذف</button></form>    \r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>";

        return new HtmlString(myTag);

    }
    public static IHtmlContent CustomModalDeleteScriptHtmlHelper(this IHtmlHelper htmlHelper, string path)
    {

        string myTag = $"\t<script src=\"~/Admin/MainTemplate/Scripts/modal.js\"></script> <script>\r\n\r\n    function Delete(id) {{\r\n        $.get(\"/Admin/{path}\" + id, function (resualt) {{\r\n\r\n        }});\r\n    }}\r\n    \tvar divElements = document.querySelectorAll('.button-modal');\r\n\r\n\tdivElements.forEach(function(div) {{\r\n\t\tdiv.addEventListener('click', (e)=> {{\r\n\t\t\t    let Id=e.target.getAttribute(\"content-Id\");\r\n\t\t\t\tconsole.log(Id);\r\n\t\t\t\tdocument.querySelector(\"#Id\").setAttribute(\"value\", Id);\r\n\t\t\t}});\r\n\t\t}});</script>";

        return new HtmlString(myTag);

    }
    public static IHtmlContent CustomMessageForTableHtmlHelper(this IHtmlHelper htmlHelper, string title, string path)
    {

        string myTag = $"      <div class=\"alert alert-info\" role=\"alert\">\r\n                <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-hidden=\"true\">×</button>\r\n            <strong>{title} ای موجود نیس</strong> .<a href=\"/Admin/{path}\" class=\"alert-link\"> ثبت {title}  جدید</a> برای ساخت {title} لازم است\r\n            </div>";

        return new HtmlString(myTag);

    }
    public static IHtmlContent CustomForTableHtmlHelper(this IHtmlHelper htmlHelper, string title, List<TableInfoAdminVM> list, string ControllerName, string type, bool delete = true, bool edit = true, bool isSugestion = false)
    {



        var html = new StringBuilder();
        html.Clear();
        if (list?.Count < 1 || list == null)
        {

         
        }
        else
        {



            html.Append($@"<div class=""top-buttons-box mb-2"">
                                        <a class=""btn btn-success"" href=""/Admin/{ControllerName}/Create"">
                                            <i class=""icon-plus""></i>
                                            افزودن
                                        <div class=""paper-ripple""><div class=""paper-ripple__background""></div><div class=""paper-ripple__waves""></div></div></a>
                                    
                                    </div> 
<table class=""table table-bordered table-hover table-striped dataTable no-footer"" id=""data-table"" role=""grid"" aria-describedby=""data-table_info"" style=""width: 100%;"">
                        <thead>
                            <tr role=""row"">

<th class=""sorting"" tabindex=""0"" aria-controls=""data-table"" rowspan=""1"" colspan=""1"" aria-label=""ردیف: activate to sort column ascending"" style=""width: 109.391px;"">ردیف</th>
<th class=""sorting"" tabindex=""0"" aria-controls=""data-table"" rowspan=""1"" colspan=""1"" aria-label=""ماده غذایی: activate to sort column ascending"" style=""width: 287.219px;"">عنوان </th>

<td class=""sorting_disabled"" rowspan=""1"" colspan=""1"" aria-label=""عملیات"" style=""width: 247.078px;"">عملیات</td>
</tr>
                        </thead>
                        <tbody>
");

            foreach (var item in list)
            {
                var newId = item?.Id ?? item.ID;

                string Id = "";
                if (type.Equals("Blog"))
                {
                    string PathImage = item.ImagePath.ImageForBlogUrl();
                    string Imagetag = $"<a href=\"/{type}/{item.Id}/{item.Title} \"><img src=\"{PathImage}\" width=\"25\" height=\"25\" alt=\"{item.Title}\" /></a>";
                    Id = Imagetag;
                }
                else if (type.Equals("Product"))
                {
                    string PathProductImage = item.ImagePath?.SetForProductUrl();
                    string Imagetag = $"<a href=\"/{type}/{item.Id}/{item.Title} \"><img src=\"{PathProductImage}\" width=\"25\" height=\"25\" alt=\"{item.Title}\" /></a>";
                    Id = Imagetag;
                }
                else if (type.Equals("BlogComment"))
                {
                    string Imagetag = $"<a href=\"/Blog/{item.Title} \">{newId}</a>";
                    Id = Imagetag;
                }



                else
                    Id = newId;
                string status = item.Status ? "<i class=\"fa-solid fa-circle-check\"></i>" : "<i class=\"fa-solid fa-circle-xmark\"></i>";
                string IsSugestionHomePage = isSugestion ? "<i class=\"fa-solid fa-circle-check\"></i>" : "";
                string EditTag = edit ? $"   <a href=\"/Admin/{ControllerName}/Edit/{newId}\" class=\"btn btn-info\">ویرایش<div class=\"paper-ripple\"><div class=\"paper-ripple__background\"></div><div class=\"paper-ripple__waves\"></div></div></a>" : "";
                string DeleteTag = delete ? $"                     <a href=\"/Admin/{ControllerName}/Delete/{newId}\" class=\"btn btn-danger\">حذف<div class=\"paper-ripple\"><div class=\"paper-ripple__background\"></div><div class=\"paper-ripple__waves\"></div></div></a>" : "";


                html.Append($@"""


                            <tr role=""row"" class=""odd"">
                               <td>{Id}</td>
	                            <td>{item.Title} </td>
	               
	                            <td>
		                 {EditTag}
		                     {DeleteTag}
	                            </td>
                            </tr>
                   
                     
                 """);
            }
            html.Append($"<   </tbody>\r\n\t\t\t\t    </table>");

        }

        return new HtmlString(html.ToString());

    }
    public static IHtmlContent CustomForTableHtmlHelper(this IHtmlHelper htmlHelper, string title, TableVM list, string ControllerName, string type, bool delete = true, bool edit = true, bool isSugestion = false)
    {

        var html = new StringBuilder();

        if (list?.Tables?.Count < 1 || list == null)
        {

            html.Append($"    <div dir=\"rtl\" class=\"alert alert-primary alert-dismissible text-center d-flex align-items-center\" role=\"alert\">\r\n\t<i class=\"bx bx-xs bx-command me-2\"></i>\r\n\t     <strong>{title} ای موجود نیس</strong> .<a href=\"/Admin/{ControllerName}/Create\" class=\"alert-link\"> ثبت {title}  جدید</a> برای ساخت {title} لازم است\r\n  \r\n\t<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\">\r\n\t</button>\r\n</div>");

        }
        else
        {
            html.Append($"  \t\t<div class=\"card-body\" dir=\"rtl\">  \r\n\t\t\t<a id=\"table2-new-row-button\" href=\"/Admin/{ControllerName}/Create\" class=\"btn btn-primary mb-4\">  <i class=\"fa-regular fa-square-plus\"></i></a>\r\n\t\t\t<div class=\"table-responsive\">\r\n\t\t\t\t<table dir=\"rtl\" class=\"table table-bordered border text-nowrap mb-0\" id=\"new-edit\">\r\n\t\t\t\t\t<thead>\r\n\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t<th>کد</th>\r\n\t\t\t\t\t\t\t<th>\r\n\t\t\t\t\t\t\t\tعنوان\r\n\t\t\t\t\t\t\t</th>\r\n\t\t\t\t\t\t\t<th> تاریخ انتشار </th>\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<th name=\"bstable-actions\"></th>\r\n\t\t\t\t\t\t</tr>\r\n\t\t\t\t\t</thead>\r\n\t\t\t\t\t<tbody>\r\n\t\t\t\t\t\t");


            foreach (var item in list?.Tables)
            {
                var link_String = new StringBuilder();
                var newId = item?.Id ?? item.ID;



                string Id = "";
                if (type.Equals("Blog"))
                {
                    string PathImage = item.ImagePath?.SetForBlogUrl();
                    string Imagetag = $"<a href=\"/{type}/{item.Id}/{item.Title} \"><img src=\"{PathImage}\" width=\"25\" height=\"25\" alt=\"{item.Title}\" /></a>";
                    Id = Imagetag;
                }
                else if (type.Equals("Product"))
                {
                    string PathProductImage = item.ImagePath?.SetForProductUrl();
                    string Imagetag = $"<a href=\"/{type}/{item.Id}/{item.Title} \"><img src=\"{PathProductImage}\" width=\"25\" height=\"25\" alt=\"{item.Title}\" /></a>";
                    Id = Imagetag;
                }

                else
                    Id = newId;

                string status = item.Status ? "<i class=\"fa-solid fa-circle-check\"></i>" : "<i class=\"fa-solid fa-circle-xmark\"></i>";
                string EditTag = edit ? $"<a id=\"bEdit\" href=\"/Admin/{ControllerName}/Edit/{newId}\" class=\"btn btn-sm\" title=\"ویرایش\">\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"bx bx-edit-alt\"> </span>\r\n\t\t\t\t\t\t\t\t\t\t</a>" : "";
                string DeleteTag = delete ? $"<a id=\"bDel\" content-Id=\"{newId}\" data-bs-target=\"#modaldemo5\" data-bs-toggle=\"modal\" class=\"btn  btn-sm button-modal \" title=\"حذف \">\r\n\t\t\t\t\t\t\t\t\t\t\t<span content-Id=\"{newId}\" class=\"bx bxs-message-square-x\"> </span>\r\n\t\t\t\t\t\t\t\t\t\t</a>" : "";

                foreach (var link in list.Links)
                {
                    link_String.Append($"<a id=\"bEdit\" href=\"{link.Link}/{newId}\" class=\"btn btn-sm\" title=\"{string.Format(link.Title, item.Title)}\">\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"{link.Icons}\"> </span>\r\n\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t\t");
                }

                var isSugestionTempelate = isSugestion ? $" <a id=\"bEdit\" href=\"/Admin/{ControllerName}/Sugestion/{newId}\" class=\"btn btn-sm\" title=\"ویژه\">\r\n\t\t\t\t\t\t\t\t\t\t\t<i class=\"fa-solid fa-circle-check\"></i> </a>" : "";

                html.Append($"\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t\t<td>{Id}</td>\r\n\t\t\t\t\t\t\t\t<td>{item.Title}</td>\r\n\t\t\t\t\t\t\t\t<td>{item.Date.ConvertDateToPersion()}</td>\r\n\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\r\n\r\n\t\t\t\t\t\t\t\t<td name=\"bstable-actions\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"btn-list\">\r\n\t\t\t\t\t\t\t\t\t\t" +
                    $"{link_String.ToString()} {isSugestionTempelate}{EditTag}\r\n\t\t\t\t\t\t\t\t\t\t<a id=\"bEdit\" href=\"/Admin/{ControllerName}/Active/{newId}\" class=\"btn btn-sm \" title=\"وضعیت \">\r\n\t\t\t\t\t\t\t\t\t\t\t{status}\r\n\r\n\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t{DeleteTag}\r\n\t\t\t\t\t\t\t\t\t\t<button id=\"bAcep\" type=\"button\" class=\"btn  btn-sm btn-primary\" style=\"display:none;\">\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"fe fe-check-circle\"> </span>\r\n\t\t\t\t\t\t\t\t\t\t</button>\r\n\t\t\t\t\t\t\t\t\t\t<button id=\"bCanc\" type=\"button\" class=\"btn  btn-sm btn-danger\" style=\"display:none;\">\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"fe fe-x-circle\"> </span>\r\n\t\t\t\t\t\t\t\t\t\t</button>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t</tr>\r\n\t\t\t\t\t\t\r\n\r\n\r\n\t\t\t\t\t"
                );
            }
            html.Append($"</tbody>\r\n\t\t\t\t</table>\r\n\t\t\t</div>\r\n\t\t</div> ");

        }

        return new HtmlString(html.ToString());

    }

    //public static IHtmlContent CustomForDropDownHelper(this IHtmlHelper htmlHelper, string name, string title, List<DropDownList> list)
    //{

    //	var html = new StringBuilder();
    //	html.Append($@" <div class=""col-lg-12 d-flex justify-content-start"">
    //                       <div class=""form-group""><label for="""">{title}</label>
    //                       <select name=""{name}"" class=""form-control"">");
    //	foreach (var item in list)
    //	{
    //		var selected = item.IsSelected ? "selected" : "";

    //		html.Append($@"           <option {selected} value=""{item.Value}"">{item.Title} </option>");
    //	}
    //	html.Append($@"     </select> 
    //                       </div>
    //                   </div>");

    //	return new HtmlString(html.ToString());

    //}

    public static IHtmlContent CustomPagInationHelper(this IHtmlHelper htmlHelper, string ControllerName, int Count, int PageNumber)
    {

        var html = new StringBuilder();
        var statusPagePre = PageNumber == 0 ? "disabled" : "";
        var statusPageNext = PageNumber + 1 == Count ? "disabled" : "";

        html.Append($"<nav aria-label=\"Page navigation\" class=\"d-flex justify-content-center mt-5\"><ul class=\"pagination pagination-lg\"><li class=\"page-item prev {statusPagePre}\"><a class=\"page-link\" href=\"/Admin/{ControllerName}/Index/{PageNumber - 1}\"><i class=\"  fas fa-angle-right\"></i></a></li>");
        for (int i = 0; i < Count; i++)
        {
            if (i.Equals(PageNumber))
            {
                html.Append($"	<li class=\"page-item disabled\">  <a class=\"page-link\" href=\"/Admin/{ControllerName}/Index/{i}\" tabindex=\"-1\">{i + 1}</a></li>");

            }
            else
            {
                html.Append($"	<li class=\"page-item\"><a class=\"page-link\" href=\"/Admin/{ControllerName}/Index/{i}\">{i + 1}</a></li>");

            }
        }
        html.Append($"<li class= \"page-item next {statusPageNext}\" ><a class=\"page-link\" href= \"/Admin/{ControllerName}/Index/{PageNumber + 1}\" ><i class=\" fas fa-angle-left\"></i></a></li></ul></nav>");


        return new HtmlString(html.ToString());

    }
}

