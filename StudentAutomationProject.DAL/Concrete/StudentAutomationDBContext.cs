using Microsoft.EntityFrameworkCore;
using StudentAutomationProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.DAL.Concrete
{
    public partial class StudentAutomationDBContext : DbContext
    {
        public StudentAutomationDBContext()
        {
        }

        public StudentAutomationDBContext(DbContextOptions<StudentAutomationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CourseRegistration> CourseRegistration { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<DepartmentPersons> DepartmentPersons { get; set; }
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
                optionsBuilder.UseSqlServer("Server=DESKTOP-RHAN2O7;Database=StudentAutomationDB;User ID=serdar2;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
          

            modelBuilder.Entity<CourseRegistration>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseRegistration)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseRegistration_Courses");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CourseRegistration)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseRegistration_Students");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Courses_Departments");
            });

            modelBuilder.Entity<DepartmentPersons>(entity =>
            {
                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentPersons)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentPersons_Departments");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DepartmentPersons)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentPersons_Students");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.DepartmentPersons)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentPersons_Teachers");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ExamResults>(entity =>
            {
                entity.Property(e => e.Grade).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamResults)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamResults_Exams");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamResults)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamResults_Students");
            });

            modelBuilder.Entity<Exams>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TcNo)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentAffairs>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.StudentAffairs)
                    .HasForeignKey<StudentAffairs>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentAffairs_Persons");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Students)
                    .HasForeignKey<Students>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Persons");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Teachers)
                    .HasForeignKey<Teachers>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teachers_Persons");
            });
        }
    }
}
