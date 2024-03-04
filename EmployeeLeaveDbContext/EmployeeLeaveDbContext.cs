using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseContext
{
    public class EmployeeLeaveDbContext : IdentityDbContext<User>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<EmployeeLeave> EmployeesLeaves { get; set; }


        public EmployeeLeaveDbContext(DbContextOptions<EmployeeLeaveDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EmployeeLeave>()
                    .HasOne(e => e.Employee)
                    .WithMany(el => el.EmployeeLeaves)
                    .HasForeignKey(e => e.EmployeeGuid);
            modelBuilder.Entity<EmployeeLeave>()
                    .HasOne(l => l.Leave)
                    .WithMany(el => el.EmployeeLeaves)
                    .HasForeignKey(l => l.LeaveId);
            modelBuilder.Entity<EmployeeLeave>()
                  .HasOne(y => y.Year)
                  .WithMany(el => el.EmployeesLeaves)
                  .HasForeignKey(y => y.YearId);

            modelBuilder.Entity<LeaveRequest>()
                    .HasOne(e => e.Employee)
                    .WithMany(el => el.LeaveRequests)
                    .HasForeignKey(e => e.EmployeeGuid);
            modelBuilder.Entity<LeaveRequest>()
                    .HasOne(l => l.Leave)
                    .WithMany(el => el.LeaveRequests)
                    .HasForeignKey(l => l.LeaveId);
            modelBuilder.Entity<LeaveRequest>()
                  .HasOne(y => y.Year)
                  .WithMany(el => el.LeaveRequests)
                  .HasForeignKey(y => y.YearId);

            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }


        public void SeedData(ModelBuilder modelBuilder)
        {
            List<Year> years = new List<Year>()
            {
                new() {Id = 1, YearValue = 2024}
            };
            modelBuilder.Entity<Year>().HasData(years);

            List<Leave> leaves = new List<Leave>
            {
                new () { Id = 1, Type = "Schedule", DefaultDays = 14 , IsDefault = true},
                new () { Id = 2, Type = "Casual", DefaultDays = 7 , IsDefault = true}
            };
            modelBuilder.Entity<Leave>().HasData(leaves);

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new () { Name = "Admin", NormalizedName = "ADMIN" },
                new () { Name = "User", NormalizedName = "USER" }

            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
