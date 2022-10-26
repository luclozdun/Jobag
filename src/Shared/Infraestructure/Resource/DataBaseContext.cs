using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Jobag.src.Shared.Infraestructure.Resource
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Postulant> Postulants { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillPostulant> SkillPostulants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Postulant>(postulant =>
            {
                postulant.ToTable("Postulant");
                postulant.HasKey(x => x.Id);
                postulant.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

                postulant.Property(x => x.FirstName).HasColumnName("FirstName");

                postulant.Property(x => x.LastName).HasColumnName("LastName");

                postulant.OwnsOne(o => o.Email, conf =>
                conf.Property(x => x.Value).HasColumnName("Email"));

                postulant.OwnsOne(o => o.Number, conf =>
                conf.Property(x => x.Value).HasColumnName("Number"));

                postulant.OwnsOne(o => o.Password, conf =>
                conf.Property(x => x.Value).HasColumnName("Password"));

                postulant.OwnsOne(o => o.Document, conf =>
                conf.Property(x => x.Value).IsRequired().HasMaxLength(30).HasColumnName("Document"));

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
        }
    }
}