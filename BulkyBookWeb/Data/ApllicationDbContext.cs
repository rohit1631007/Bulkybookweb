
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
namespace BulkyBookWeb.Data;

    public class ApllicationDbContext:DbContext
    {
        public ApllicationDbContext(DbContextOptions<ApllicationDbContext> options) : base(options)
        {   
        }
        public DbSet<Category> Categories {  get; set; }
    }

