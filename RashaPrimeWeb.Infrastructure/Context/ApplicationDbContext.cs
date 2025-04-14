using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Common;
using RashaPrimeWeb.DataLayer.Context;
using RashaPrimeWeb.Domain.Entities;
using System;

namespace RashaPrimeWeb.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : AuditableDbContext(options)
{
    #region define Tables

    public DbSet<UserApplication> Users { get; set; } = default!;
    public DbSet<Blog> Blog { get; set; } = default!;
    public DbSet<Language> Languages { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<Blog> Comments { get; set; } = default!;
    public DbSet<CategoryToBlog> CategoryToBlog { get; set; } = default!;
    public DbSet<CategoryToService> CategoryToService { get; set; } = default!;
    public DbSet<CategoryToNews> CategoryToNews { get; set; } = default!;
    public DbSet<CommentToBlog> CommentToBlog { get; set; } = default!;
    public DbSet<Faq> Faq { get; set; } = default!;
    public DbSet<FileManager> FileManager { get; set; } = default!;
    public DbSet<Setting> Setting { get; set; } = default!;
    public DbSet<FileToBlog> FileToBlog { get; set; } = default!;
    public DbSet<FileToNews> FileToNews { get; set; } = default!;
    public DbSet<FileToService> FileToService { get; set; } = default!;
    public DbSet<Menu> Menu { get; set; } = default!;
    public DbSet<News> News { get; set; } = default!;
    public DbSet<Service> Service { get; set; } = default!;
    public DbSet<Slider> Slider { get; set; } = default!;
    public DbSet<Tag> Tag { get; set; } = default!;
    public DbSet<TagToService> TagToService { get; set; } = default!;
    public DbSet<TagToBlog> TagToBlog { get; set; } = default!;
    public DbSet<TagToNews> TagToNews { get; set; } = default!;



    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<FileToBlog>().HasKey(a => new { a.BlogId, a.ImageId });
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

