using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentAutomationProject.Entities.Models;

namespace StudentAutomationProject.DAL.Concrete
{
    public partial class StudentAutoDBContext : DbContext
    {
        public StudentAutoDBContext()
        {
        }

        public StudentAutoDBContext(DbContextOptions<StudentAutoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<DepartmentPerson> DepartmentPerson { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<ExamResults> ExamResults { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<StudentAffairs> StudentAffairs { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RHAN2O7;Database=StudentAutoDB;User ID=serdar2;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentUid).HasColumnName("DepartmentUID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(p => p.Id)
                 .UseSqlServerIdentityColumn();
                entity.Property(p => p.Id)
                    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.DepartmentU)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentUid)
                    .HasConstraintName("FK_Courses_Departments");
            });

            modelBuilder.Entity<DepartmentPerson>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentUid).HasColumnName("DepartmentUID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonUid).HasColumnName("PersonUID");

                entity.HasOne(d => d.DepartmentU)
                    .WithMany(p => p.DepartmentPerson)
                    .HasForeignKey(d => d.DepartmentUid)
                    .HasConstraintName("FK_DepartmentPerson_Departments");

                entity.HasOne(d => d.PersonU)
                    .WithMany(p => p.DepartmentPerson)
                    .HasForeignKey(d => d.PersonUid)
                    .HasConstraintName("FK_DepartmentPerson_Students");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                //ID update sıkıntısını çözüyor
                entity.Property(p => p.Id)
                   .UseSqlServerIdentityColumn();
                entity.Property(p => p.Id)
                    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                entity.Property(e => e.Name).HasMaxLength(50);

            });

            modelBuilder.Entity<ExamResults>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExamUid).HasColumnName("ExamUID");

                entity.Property(e => e.Grade).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonUid).HasColumnName("PersonUID");

                entity.HasOne(d => d.ExamU)
                    .WithMany(p => p.ExamResults)
                    .HasForeignKey(d => d.ExamUid)
                    .HasConstraintName("FK_ExamResults_Exams");

                entity.HasOne(d => d.PersonU)
                    .WithMany(p => p.ExamResults)
                    .HasForeignKey(d => d.PersonUid)
                    .HasConstraintName("FK_ExamResults_Students");
            });

            modelBuilder.Entity<Exams>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseUid).HasColumnName("CourseUID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.TcNo)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(p => p.Id)
                    .UseSqlServerIdentityColumn();
                entity.Property(p => p.Id)
                    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
            });

            modelBuilder.Entity<StudentAffairs>(entity =>
            {
                entity.HasKey(e => e.PersonUid);

                entity.Property(e => e.PersonUid)
                    .HasColumnName("PersonUID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.PersonU)
                    .WithOne(p => p.StudentAffairs)
                    .HasForeignKey<StudentAffairs>(d => d.PersonUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentAffairs_Persons");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.PersonUid);

                entity.Property(e => e.PersonUid)
                    .HasColumnName("PersonUID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.PersonU)
                    .WithOne(p => p.Students)
                    .HasForeignKey<Students>(d => d.PersonUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Persons");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.PersonUid);

                entity.Property(e => e.PersonUid)
                    .HasColumnName("PersonUID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.PersonU)
                    .WithOne(p => p.Teachers)
                    .HasForeignKey<Teachers>(d => d.PersonUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teachers_Persons");
            });
        }
    }
}
