using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Domain.Entities;

namespace RashaPrimeWeb.Application.Common;

public interface IApplicationDbContext
{
    public DbSet<UserApplication> Users { get;  } 
    public DbSet<Blog> Blog { get;}
    public DbSet<Language> Languages { get; }
    public DbSet<Domain.Entities.Category> Category { get;}
    public DbSet<Blog> Comments { get;}
    public DbSet<CategoryToBlog> CategoryToBlog { get;}
    public DbSet<CategoryToService> CategoryToService { get;}
    public DbSet<CategoryToNews> CategoryToNews { get;}
    public DbSet<CommentToBlog> CommentToBlog { get;}
    public DbSet<Faq> Faq { get;}
    public DbSet<FileManager> FileManager { get;}
    public DbSet<Setting> Setting { get;}
    public DbSet<FileToBlog> FileToBlog { get;}
    public DbSet<FileToNews> FileToNews { get;}
    public DbSet<FileToService> FileToService { get;}
    public DbSet<Menu> Menu { get;}
    public DbSet<News> News { get;}
    public DbSet<Service> Service { get;}
    public DbSet<Slider> Slider { get;}
    public DbSet<Tag> Tag { get;}
    public DbSet<TagToService> TagToService { get;}
    public DbSet<TagToBlog> TagToBlog { get;}
    public DbSet<TagToNews> TagToNews { get;}



    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
