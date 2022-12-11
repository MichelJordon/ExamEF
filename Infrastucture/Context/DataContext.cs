using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    #region Methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().
          HasOne(e => e.Manager).
          WithMany().
          HasForeignKey(m => m.ManagerId);
    }
    #endregion

    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<JobGrade> JobGrades { get; set; }
    public DbSet<JobHistory> JobHistories { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Region> Regions { get; set; }
}