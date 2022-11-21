using Jobag.src.Ability.Domain.Model.Aggregates;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Shared.Infraestructure.Resource
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Postulant> Postulants { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SkillPostulant> SkillPostulants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PlanEmployee> PlanEmployees { get; set; }
        public DbSet<PlanPostulant> PlanPostulants { get; set; }
        public DbSet<OrderEmployee> OrderEmployees { get; set; }
        public DbSet<OrderPostulant> OrderPostulants { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Postulant>(postulant =>
            {
                postulant.ToTable("Postulants");
                postulant.HasKey(x => x.Id);
                postulant.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
                postulant.Property(x => x.FirstName).HasColumnName("FirstName");
                postulant.Property(x => x.LastName).HasColumnName("LastName");
                postulant.Property(x => x.Email).HasColumnName("Email");
                postulant.OwnsOne(o => o.Phone, conf => conf.Property(x => x.Number).HasColumnName("Phone_Number"));
                postulant.OwnsOne(o => o.Phone, conf => conf.Property(x => x.Operator).HasColumnName("Phone_Operator"));
                postulant.OwnsOne(o => o.Phone, conf => conf.Property(x => x.ZipCode).HasColumnName("Phone_ZipCode"));
                postulant.OwnsOne(o => o.Document, conf => conf.Property(x => x.Country).HasColumnName("Country"));
                postulant.OwnsOne(o => o.Document, conf => conf.Property(x => x.Dni).HasColumnName("DNI"));
                postulant.OwnsOne(o => o.Password, conf => conf.Property(x => x.Value).HasColumnName("Password"));
            });

            builder.Entity<Skill>(skill =>
            {
                skill.ToTable("Skills");
                skill.HasKey(x => x.Id);
                skill.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
                skill.Property(x => x.Name).HasColumnName("Name");
                skill.Property(x => x.Description).HasColumnName("Description");
            });

            builder.Entity<SkillPostulant>(skillPostulant =>
            {
                skillPostulant.ToTable("SkillPostulants");
                skillPostulant.HasKey(x => new { x.PostulantId, x.SkillId });
                skillPostulant.HasOne(x => x.Postulant).WithMany(x => x.SkillPostulants).HasForeignKey(x => x.PostulantId);
                skillPostulant.HasOne(x => x.Skill).WithMany(x => x.SkillPostulants).HasForeignKey(x => x.SkillId);
            });

            builder.Entity<Course>(course =>
            {
                course.ToTable("Courses");
                course.HasKey(x => x.Id);
                course.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
                course.Property(x => x.Name).HasColumnName("Name");
                course.Property(x => x.Description).HasColumnName("Description");
            });

            builder.Entity<CoursePostulant>(coursePostulant =>
            {
                coursePostulant.ToTable("CoursePostulants");
                coursePostulant.HasKey(x => new { x.PostulantId, x.CourseId });
                coursePostulant.HasOne(x => x.Postulant).WithMany(x => x.CoursePostulants).HasForeignKey(x => x.PostulantId);
                coursePostulant.HasOne(x => x.Course).WithMany(x => x.CoursePostulants).HasForeignKey(x => x.CourseId);
            });

            builder.Entity<Employee>(employee =>
            {
                employee.ToTable("Employees");
                employee.HasKey(x => x.Id);
                employee.Property(x => x.Id).ValueGeneratedOnAdd();
                employee.Property(x => x.FirstName).HasColumnName("FirstName");
                employee.Property(x => x.LastName).HasColumnName("LastName");
                employee.Property(x => x.Email).HasColumnName("Email");
                employee.OwnsOne(o => o.Phone, conf => conf.Property(x => x.Number).HasColumnName("Phone_Number"));
                employee.OwnsOne(o => o.Phone, conf => conf.Property(x => x.Operator).HasColumnName("Phone_Operator"));
                employee.OwnsOne(o => o.Phone, conf => conf.Property(x => x.ZipCode).HasColumnName("Phone_ZipCode"));
                employee.OwnsOne(o => o.Document, conf => conf.Property(x => x.Country).HasColumnName("Country"));
                employee.OwnsOne(o => o.Document, conf => conf.Property(x => x.Dni).HasColumnName("DNI"));
                employee.OwnsOne(o => o.Password, conf => conf.Property(x => x.Value).HasColumnName("Password"));
                employee.HasOne(o => o.Company).WithMany(x => x.Employees).HasForeignKey(x => x.Id);
            });

            builder.Entity<Company>(company =>
            {
                company.ToTable("Companies");
                company.HasKey(x => x.Id);
                company.Property(x => x.Id).ValueGeneratedOnAdd();
                company.Property(x => x.Name).HasColumnName("Name");
                company.Property(x => x.Description).HasColumnName("Description");
                company.OwnsOne(x => x.Phone, conf => conf.Property(x => x.Number).HasColumnName("Phone_Number"));
                company.OwnsOne(x => x.Phone, conf => conf.Property(x => x.Operator).HasColumnName("Phone_Operator"));
                company.OwnsOne(x => x.Phone, conf => conf.Property(x => x.ZipCode).HasColumnName("Phone_ZipCode"));
                company.OwnsOne(x => x.RUC, conf => conf.Property(x => x.CodeRuc).HasColumnName("Code_RUC"));
                company.OwnsOne(x => x.RUC, conf => conf.Property(x => x.Country).HasColumnName("Country"));
                company.OwnsOne(x => x.RUC, conf => conf.Property(x => x.Inscription).HasColumnName("Date_Incription"));
                company.OwnsOne(x => x.RUC, conf => conf.Property(x => x.Address).HasColumnName("Address"));
                company.OwnsOne(x => x.RUC, conf => conf.Property(x => x.TypeTaxPayer).HasColumnName("Type_TaxPayer"));
            });

            builder.Entity<Employee>(employee =>
            {
                employee.ToTable("Employees");
                employee.HasKey(x => x.Id);
                employee.Property(x => x.Id).ValueGeneratedOnAdd();
                employee.Property(x => x.FirstName).HasColumnName("FirstName");
                employee.Property(x => x.LastName).HasColumnName("LastName");
                employee.Property(x => x.Email).HasColumnName("Email");
                employee.OwnsOne(o => o.Phone, conf => conf.Property(x => x.Number).HasColumnName("Phone_Number"));
                employee.OwnsOne(o => o.Phone, conf => conf.Property(x => x.Operator).HasColumnName("Phone_Operator"));
                employee.OwnsOne(o => o.Phone, conf => conf.Property(x => x.ZipCode).HasColumnName("Phone_ZipCode"));
                employee.OwnsOne(o => o.Document, conf => conf.Property(x => x.Country).HasColumnName("Country"));
                employee.OwnsOne(o => o.Document, conf => conf.Property(x => x.Dni).HasColumnName("DNI"));
                employee.OwnsOne(o => o.Password, conf => conf.Property(x => x.Value).HasColumnName("Password"));
                employee.HasOne(o => o.Company).WithMany(x => x.Employees).HasForeignKey(x => x.Id);
            });

            builder.Entity<PlanEmployee>(plan =>
            {
                plan.ToTable("Plan_Employees");
                plan.HasKey(x => x.Id);
                plan.Property(x => x.Id).ValueGeneratedOnAdd();
                plan.HasMany(x => x.Employees).WithOne(x => x.PlanEmployee).HasForeignKey(x => x.Id);
                plan.Property(x => x.Name).HasColumnName("Name");
                plan.Property(x => x.Description).HasColumnName("Description");
                plan.Property(x => x.CreatedAt).HasColumnName("Created_At");
                plan.Property(x => x.UpdatedAt).HasColumnName("Updated_At");
            });

            builder.Entity<PlanPostulant>(plan =>
            {
                plan.ToTable("Plan_Employees");
                plan.HasKey(x => x.Id);
                plan.Property(x => x.Id).ValueGeneratedOnAdd();
                plan.HasMany(x => x.Postulants).WithOne(x => x.PlanPostulant).HasForeignKey(x => x.Id);
                plan.Property(x => x.Name).HasColumnName("Name");
                plan.Property(x => x.Description).HasColumnName("Description");
                plan.Property(x => x.CreatedAt).HasColumnName("Created_At");
                plan.Property(x => x.UpdatedAt).HasColumnName("Updated_At");
            });

            builder.Entity<OrderEmployee>(order =>
            {
                order.ToTable("Order_Employees");
                order.HasKey(x => x.Id);
                order.Property(x => x.Id).ValueGeneratedOnAdd();
                order.HasOne(x => x.Employee).WithMany(x => x.OrderEmployees).HasForeignKey(x => x.Id);
                order.HasOne(x => x.PlanEmployee).WithMany(x => x.OrderEmployees).HasForeignKey(x => x.Id);
                order.Property(x => x.Price).HasColumnName("Price");
                order.Property(x => x.CreatedAt).HasColumnName("Create_AT");
            });

            builder.Entity<OrderPostulant>(order =>
            {
                order.ToTable("Order_Postulants");
                order.HasKey(x => x.Id);
                order.Property(x => x.Id).ValueGeneratedOnAdd();
                order.HasOne(x => x.Postulant).WithMany(x => x.OrderPostulants).HasForeignKey(x => x.Id);
                order.HasOne(x => x.PlanPostulant).WithMany(x => x.OrderPostulants).HasForeignKey(x => x.Id);
                order.Property(x => x.Price).HasColumnName("Price");
                order.Property(x => x.CreatedAt).HasColumnName("Create_AT");
            });
        }
    }
}