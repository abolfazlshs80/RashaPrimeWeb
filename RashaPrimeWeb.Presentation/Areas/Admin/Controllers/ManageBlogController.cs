﻿using AutoMapper;

using Kashi_Seramic.MVC.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pr_Signal_ir.Application.Extentions;

using System.Collections.Generic;
using Kashi_Seramic.Application.Contracts.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.DataLayer.MVC.Models.Blog;
using RashaPrimeWeb.DataLayer.MVC.Models.CategoryToBlog;
using RashaPrimeWeb.DataLayer.MVC.Models.FileToBlog;
using RashaPrimeWeb.DataLayer.MVC.Models.TagToBlog;

namespace RashaPrimeWeb.WEB.Areas.Admin.Controllers
{

    [Area("Administrator")]
    // [Authorize(Roles = "Administrator,Teacher")]
    public class ManageBlogController(IMediator mediator) : PaginationBaseController
    {
  
        [Route("/Admin/ManageBlog/Index/{page?}")]
        [Route("/Admin/ManageBlog/Index")]
        [Route("/Admin/ManageBlog")]
        public async Task<IActionResult> Index(int page = 0)
        {
            if (string.IsNullOrEmpty(User.GetUserId()))
            {
                return RedirectToAction("Logout", "Account");
            }

          //  await _siteMap.CreateSiteMap();
            var list = await _blogService.GetBlog();
            var model = SetPageInation<BlogVM>(page, list);
            await SetViewBagAdmin(list.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.List, AdminPageType.Blog);
            return View(model);




        }
        #region Create Blog
        [HttpGet]
        [Route("/Admin/ManageBlog/Create")]
        public async Task<IActionResult> Create()
        {
            var list = await _blogService.GetBlog();
            await SetViewBagAdmin(list.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.Create, AdminPageType.Blog);
            var model = new CreateBlogVM();
            model.LinkKey = "";
            model.Owner = User.GetUserId();
            model.Seen = 0;
         
            return View(model);
        }

        [HttpPost("/Admin/ManageBlog/Create")]
        public async Task<IActionResult> Create(CreateBlogVM model)
        {
            var list = await _blogService.GetBlog();
            await SetViewBagAdmin(list.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.Create, AdminPageType.Blog);
            model.Owner = User.GetUserId();
            model.LinkKey = "";
            if (ModelState.ErrorCount <= 3)
            {
                if (model.FileForDetials == null || model.FileHeader == null)
                {
                    return View(model);
                }
                if (model.CategoryId.Count < 1 || model.TagId.Count < 1)
                {

                }

                model.Owner = User.GetUserId();
                model.CreatedBy = User.Identity.Name;
                var resBlog = await _blogService.CreateBlog(model);
                var BlogId = resBlog.Data;
                if (resBlog.Success)
                {
                    foreach (var item in model.CategoryId)
                    {
                        await _blogcate.CreateCategoryToBlog(
                                    new CreateCategoryToBlogVM
                                    {
                                        BlogId = BlogId,
                                        CategoryId = item
                                    });
                    }



                    foreach (var item in model.TagId ?? Enumerable.Empty<int>())
                    {
                        var resTag = await _tagToBlogService.CreateTagToBlog(new CreateTagToBlogVM()
                        { BlogId = BlogId, TagId = item });
                    }

                    #region File


                    var filename = model.TitleBrowser.Replace(" ", "-");
                    var rnd = new Random().Next(1000, 99999).ToString();
                    var Name = await _fileuploader.CreateFileLocal(model.FileHeader, "Blog", rnd, filename, "-Slider");
                    var resBlogSlider = await _file.CreateFileImages(new Pr_Signal_ir.MVC.Models.FileImages.CreateFileImagesVM
                    {
                        Owner = model.Owner,
                        DateCreated = DateTime.Now,

                        IsUploaderFile = false,
                        Title = model.TitleBrowser,
                        Path = Name,
                        Type = "Blog"
                    });

                    var filetoblog = await _blogfile.CreateFileToBlog(new CreateFileToBlogVM
                    {
                        BlogId = BlogId,
                        ImageId = resBlogSlider.Data
                    });
                    if (filetoblog.Success)
                    {
                        var NameBG = await _fileuploader.CreateFileLocal(model.FileForDetials, "Blog", rnd, filename, "-BG");
                        return RedirectToAction("Index");

                    }

                    #endregion




                }
            }


            return View(model);
        }

        #endregion
        #region Edit Blog
        [HttpGet]
        [Route("/Admin/ManageBlog/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var list = await _blogService.GetBlog();
            await SetViewBagAdmin(list.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.Update, AdminPageType.Blog);
            //  string userId = User.FindFirst("uid")?.ToString().Replace("uid: ", "");
            //var user = await _userService.GetEmployee(userId);

            var model = await _blogService.GetBlogDetails(id);
            if (model == null)
                return NotFound();
            //if (User.IsInRole("Teacher"))
            //{
            //    if ((await _blogService.UserInOwner(userId, id)).Success)
            //        return View(_mapper.Map<UpdateBlogVM>(model));
            //    else
            //        return RedirectToAction("Index");
            //}
            //else

            var newmodel = _mapper.Map<UpdateBlogVM>(model);
            newmodel.CategoryId = model.CategoryToBlog.Select(a => a.CategoryId).ToList();
            return View(newmodel);

        }

        [HttpPost("/Admin/ManageBlog/Edit/{Id}")]
  
        public async Task<IActionResult> Edit(UpdateBlogVM model,int Id)
        {
            var list = await _blogService.GetBlog();
            await SetViewBagAdmin(list.Select(a => a.TitleBrowser).ToList(), AdminPageViewType.Update, AdminPageType.Blog);


            try
            {
                var Blog = await _blogService.GetBlogDetails(model.Id);
                model.LastModifiedBy = User.GetNameUser();
                model.LinkKey = Blog.LinkKey;
                model.Lang_Id = Blog.Lang_Id;
                var resBlog = await _blogService.UpdateBlog(model.Id, model);
                if (resBlog.Success)
                {
                    if (model.CategoryId != null)
                    {
                        foreach (var item in Blog.CategoryToBlog)
                        {
                            await _blogcate.DeleteCategoryToBlog(item.BlogId);
                        }
                        
                        foreach (var item in model.CategoryId)
                        {
                            await _blogcate.CreateCategoryToBlog(
                                new CreateCategoryToBlogVM
                                {
                                    BlogId = model.Id,
                                    CategoryId = item
                                });
                        }
                    }

                    if (model.TagId != null)
                    {
                        foreach (var item in Blog.TagToBlog)
                        {
                            await _tagToBlogService.DeleteTagToBlog(item.BlogId);
                        }
            //            await _tagToBlogService.DeleteAnyTagToBlog(Blog.Id);
                        foreach (var item in model.TagId ?? Enumerable.Empty<int>())
                        {

                            var resTag = await _tagToBlogService.CreateTagToBlog(new CreateTagToBlogVM()
                            { BlogId = Blog.Id, TagId = item });
                        }

                    }


                    if (model.FileHeader != null && model.FileForDetials != null)
                    {
                        var path = Blog.FileToBlog.FirstOrDefault()?.FileManager.Path;
                        var path2 = path.Replace("-Slider", "-BG");
                        await _fileuploader.DeleteFileLocal("Blog", path, "Blog");
                        await _fileuploader.DeleteFileLocal("Blog", path2, "Blog");
                        await _blogfile.DeleteFileToBlog(model.Id);
                        #region Create FIle
                        var filename = model.TitleBrowser.Replace(" ", "-");
                        var rnd = new Random().Next(1000, 99999).ToString();
                        var Name = await _fileuploader.CreateFileLocal(model.FileHeader, "Blog", rnd, filename, "-Slider");
                        var resBlogSlider = await _file.CreateFileImages(new Pr_Signal_ir.MVC.Models.FileImages.CreateFileImagesVM
                        {
                            CreatedBy = "abolfazl",
                            DateCreated = DateTime.Now,
                            IsUploaderFile = false,
                            Title = model.TitleBrowser,
                            Path = Name,
                            Type = "Blog"
                        });

                        var filetoblog = await _blogfile.CreateFileToBlog(new CreateFileToBlogVM
                        {
                            BlogId = model.Id,
                            ImageId = resBlogSlider.Data
                        });
                        if (filetoblog.Success)
                        {
                            var NameBG = await _fileuploader.CreateFileLocal(model.FileForDetials, "Blog", rnd, filename, "-BG");
                            return RedirectToAction("Index");

                        }
                        #endregion
                    }



                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");

            }




            return View(model);
        }

        #endregion

        #region Delete Blog
        [HttpPost("/Admin/ManageBlog/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var blog = await _blogService.GetBlogDetails(id);
                if (blog == null)
                    return RedirectToAction("Index");

                if (blog.FileToBlog != null)
                {
                    try
                    {
                        var path = blog.FileToBlog.FirstOrDefault()?.FileManager?.Path;
                        var path2 = path?.Replace("-Slider", "-BG");
                        await _fileuploader.DeleteFileLocal("Blog", path, "Blog");
                        await _fileuploader.DeleteFileLocal("Blog", path2, "Blog");
                    }
                    catch (Exception e)
                    {

                    }


                    //await _file.DeleteFileImages(blog.FileToBlog.FirstOrDefault().BlogId);
                }
                await _blogService.DeleteBlog(id);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }


        }
        #endregion

        [Route("/Admin/ManageBlog/Active/{id}")]
        public async Task<IActionResult> Active(int id)
        {
            var model = await _blogService.GetBlogDetails(id);
            if (model == null)
            {
                return NotFound();
            }

            model.Status = !model.Status;
            await _blogService.UpdateBlog(model.Id, _mapper.Map<UpdateBlogVM>(model));
            return RedirectToAction("Index");
        }
        [HttpGet("/FindTag/{Tagname}")]
        public async Task<IActionResult> FindTag(string Tagname)
        {
            var model = await _tagService.GetTag();
            return View("FindTag", model.Where(a => a.Name.Contains(Tagname)));
        }

    }
}
