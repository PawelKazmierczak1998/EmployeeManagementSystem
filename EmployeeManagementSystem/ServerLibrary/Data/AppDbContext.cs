using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;


namespace ServerLibrary.Data
{
  
        public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
        {


        public DbSet<Employee> Employees { get; set; }
        // General Department / Department / Branch
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }

        // Country/ City / Town 
        public DbSet<Country> Countrys { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Town> Towns { get; set; }

        // Authentication / Role / System Role
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }

        //Other / Vacattion / Sanction / Doctor / Overtime

        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationType> VacationsTypes { get; set; }

        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<OvertimeType> OvertimesTypes { get; set; }

        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<SanctionType> SanctionTypes { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

    }
}
