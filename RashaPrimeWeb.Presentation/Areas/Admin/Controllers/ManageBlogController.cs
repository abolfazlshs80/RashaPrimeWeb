using System.Security.Claims;
using AutoMapper;


using Microsoft.CodeAnalysis.CSharp.Syntax;



using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Blog.Commands.CreateBlog;
using RashaPrimeWeb.Application.CQRS.Blog.Commands.UpdateBlog;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetBlog;


namespace RashaPrimeWeb.WEB.Areas.Admin.Controllers
{

    [Area("Admin")]
    // [Authorize(Roles = "Administrator,Teacher")]
    public class ManageBlogController(IMediator mediator,IMapper mapper) : PaginationBaseController(mediator)
    {

        [Route("/Admin/ManageBlog/Index/{page?}")]
        [Route("/Admin/ManageBlog/Index")]
        [Route("/Admin/ManageBlog")]
        public async Task<IActionResult> Index(int page = 0)
        {
            //if (string.IsNullOrEmpty(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            //{
            //    return RedirectToAction("Logout", "Account");
            //}
            var queryBlog = new GetAllBlogQuery(null, GetOldest, Page, Take);
            //  await _siteMap.CreateSiteMap();
            var list = await mediator.Send(queryBlog);
            var model = SetPageInation<GetAllBlogDto>(page, list.Items);
            await SetViewBagAdmin(list.Items.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.List, AdminPageType.Blog);
            return View(model);




        }
        #region Create Blog
        [HttpGet]
        [Route("/Admin/ManageBlog/Create")]
        public async Task<IActionResult> Create()
        {
            var queryBlog = new GetAllBlogQuery(null, GetOldest, Page, Take);
            var list = await mediator.Send(queryBlog);
            await SetViewBagAdmin(list.Items.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.Create, AdminPageType.Blog);
            var model = new CreateBlogCommand();

            return View(model);
        }

        [HttpPost("/Admin/ManageBlog/Create")]
        public async Task<IActionResult> Create(CreateBlogCommand model)
        {
            var queryBlog = new GetAllBlogQuery(null, GetOldest, Page, Take);
            var list = await mediator.Send(queryBlog);
            await SetViewBagAdmin(list.Items.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.Create, AdminPageType.Blog);

            if (ModelState.IsValid )
            {
                if (model.FileForDetials == null || model.FileHeader == null || model.CategoryId.Count < 1 || model.TagId.Count < 1)
                {
                    return View(model);
                }
                var result = await mediator.Send(model);
                if (result.IsError)
                    return View(model);
                return RedirectToAction("Index");
            }


            return View(model);
        }
        #endregion

        #region Edit Blog
        [HttpGet]
        [Route("/Admin/ManageBlog/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var queryBlog = new GetAllBlogQuery(null, GetOldest, Page, Take);
            var list = await mediator.Send(queryBlog);
            await SetViewBagAdmin(list.Items.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.Update, AdminPageType.Blog);

            var model =  new GetBlogQuery(id);
            var newmodel = await mediator.Send(model);
            if (model == null)
                return NotFound();
     
       
            return View(mapper.Map<UpdateBlogCommand>(newmodel));

        }

        //[HttpPost("/Admin/ManageBlog/Edit/{Id}")]

        //public async Task<IActionResult> Edit(UpdateBlogVM model,int Id)
        //{
        //    var list = await _blogService.GetBlog();
        //    await SetViewBagAdmin(list.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.Update, AdminPageType.Blog);


        //    try
        //    {
        //        var Blog = await _blogService.GetBlogDetails(model.Id);
        //        model.LastModifiedBy = User.GetNameUser();
        //        model.LinkKey = Blog.LinkKey;
        //        model.Lang_Id = Blog.Lang_Id;
        //        var resBlog = await _blogService.UpdateBlog(model.Id, model);
        //        if (resBlog.Success)
        //        {
        //            if (model.CategoryId != null)
        //            {
        //                foreach (var item in Blog.CategoryToBlog)
        //                {
        //                    await _blogcate.DeleteCategoryToBlog(item.BlogId);
        //                }

        //                foreach (var item in model.CategoryId)
        //                {
        //                    await _blogcate.CreateCategoryToBlog(
        //                        new CreateCategoryToBlogVM
        //                        {
        //                            BlogId = model.Id,
        //                            CategoryId = item
        //                        });
        //                }
        //            }

        //            if (model.TagId != null)
        //            {
        //                foreach (var item in Blog.TagToBlog)
        //                {
        //                    await _tagToBlogService.DeleteTagToBlog(item.BlogId);
        //                }
        //    //            await _tagToBlogService.DeleteAnyTagToBlog(Blog.Id);
        //                foreach (var item in model.TagId ?? Enumerable.Empty<int>())
        //                {

        //                    var resTag = await _tagToBlogService.CreateTagToBlog(new CreateTagToBlogVM()
        //                    { BlogId = Blog.Id, TagId = item });
        //                }

        //            }


        //            if (model.FileHeader != null && model.FileForDetials != null)
        //            {
        //                var path = Blog.FileToBlog.FirstOrDefault()?.FileManager.Path;
        //                var path2 = path.Replace("-Slider", "-BG");
        //                await _fileuploader.DeleteFileLocal("Blog", path, "Blog");
        //                await _fileuploader.DeleteFileLocal("Blog", path2, "Blog");
        //                await _blogfile.DeleteFileToBlog(model.Id);
        //                #region Create FIle
        //                var filename = model.TitleBrowser.Replace(" ", "-");
        //                var rnd = new Random().Next(1000, 99999).ToString();
        //                var Name = await _fileuploader.CreateFileLocal(model.FileHeader, "Blog", rnd, filename, "-Slider");
        //                var resBlogSlider = await _file.CreateFileImages(new Pr_Signal_ir.MVC.Models.FileImages.CreateFileImagesVM
        //                {
        //                    CreatedBy = "abolfazl",
        //                    DateCreated = DateTime.Now,
        //                    IsUploaderFile = false,
        //                    Title = model.TitleBrowser,
        //                    Path = Name,
        //                    Type = "Blog"
        //                });

        //                var filetoblog = await _blogfile.CreateFileToBlog(new CreateFileToBlogVM
        //                {
        //                    BlogId = model.Id,
        //                    ImageId = resBlogSlider.Data
        //                });
        //                if (filetoblog.Success)
        //                {
        //                    var NameBG = await _fileuploader.CreateFileLocal(model.FileForDetials, "Blog", rnd, filename, "-BG");
        //                    return RedirectToAction("Index");

        //                }
        //                #endregion
        //            }



        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("Index");

        //    }




        //    return View(model);
        //}

        #endregion

        //#region Delete Blog
        //[HttpPost("/Admin/ManageBlog/Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {

        //        var blog = await _blogService.GetBlogDetails(id);
        //        if (blog == null)
        //            return RedirectToAction("Index");

        //        if (blog.FileToBlog != null)
        //        {
        //            try
        //            {
        //                var path = blog.FileToBlog.FirstOrDefault()?.FileManager?.Path;
        //                var path2 = path?.Replace("-Slider", "-BG");
        //                await _fileuploader.DeleteFileLocal("Blog", path, "Blog");
        //                await _fileuploader.DeleteFileLocal("Blog", path2, "Blog");
        //            }
        //            catch (Exception e)
        //            {

        //            }


        //            //await _file.DeleteFileImages(blog.FileToBlog.FirstOrDefault().BlogId);
        //        }
        //        await _blogService.DeleteBlog(id);

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {

        //        return RedirectToAction("Index");
        //    }


        //}
        //#endregion

        //[Route("/Admin/ManageBlog/Active/{id}")]
        //public async Task<IActionResult> Active(int id)
        //{
        //    var model = await _blogService.GetBlogDetails(id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }

        //    model.Status = !model.Status;
        //    await _blogService.UpdateBlog(model.Id, _mapper.Map<UpdateBlogVM>(model));
        //    return RedirectToAction("Index");
        //}
        //[HttpGet("/FindTag/{Tagname}")]
        //public async Task<IActionResult> FindTag(string Tagname)
        //{
        //    var model = await _tagService.GetTag();
        //    return View("FindTag", model.Where(a => a.Name.Contains(Tagname)));
        //}

    }
}
