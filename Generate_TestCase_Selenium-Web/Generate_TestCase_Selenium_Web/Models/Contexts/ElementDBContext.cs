using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Generate_TestCase_Selenium_Web.Models.ModelDB;

namespace Generate_TestCase_Selenium_Web.Models.Contexts
{
    public partial class ElementDBContext : DbContext
    {
        public ElementDBContext()
        {
        }

        public ElementDBContext(DbContextOptions<ElementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<A_tag> A_tag { get; set; }
        public virtual DbSet<Alert_message> Alert_message { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Button_tag> Button_tag { get; set; }
        public virtual DbSet<Element> Element { get; set; }
        public virtual DbSet<Element_test> Element_test { get; set; }
        public virtual DbSet<Form_elements> Form_elements { get; set; }
        public virtual DbSet<Input_elements> Input_elements { get; set; }
        public virtual DbSet<Input_testcase> Input_testcase { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Redirect_url> Redirect_url { get; set; }
        public virtual DbSet<Select_tag> Select_tag { get; set; }
        public virtual DbSet<Setting_> Setting_ { get; set; }
        public virtual DbSet<Test_case> Test_case { get; set; }
        public virtual DbSet<Url> Url { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local);Database=ElementDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<A_tag>(entity =>
            {
                entity.HasKey(e => new { e.id_a_tag, e.id_url });

                entity.HasOne(d => d.id_urlNavigation)
                    .WithMany(p => p.A_tag)
                    .HasForeignKey(d => d.id_url)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_A_tag_Url");
            });

            modelBuilder.Entity<Alert_message>(entity =>
            {
                entity.HasKey(e => new { e.id_alert, e.id_testcase, e.id_url });

                entity.HasOne(d => d.id_)
                    .WithMany(p => p.Alert_message)
                    .HasForeignKey(d => new { d.id_testcase, d.id_url })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alert_message_Test_case");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("(CONVERT([bit],(0),0))");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.AspNetUsers)
                    .HasForeignKey<AspNetUsers>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUsers_Setting_");
            });

            modelBuilder.Entity<Button_tag>(entity =>
            {
                entity.HasKey(e => new { e.id_button, e.id_url });

                entity.HasOne(d => d.id_urlNavigation)
                    .WithMany(p => p.Button_tag)
                    .HasForeignKey(d => d.id_url)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Button_tag_Url");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasKey(e => new { e.id_element, e.id_url });

                entity.HasOne(d => d.id_urlNavigation)
                    .WithMany(p => p.Element)
                    .HasForeignKey(d => d.id_url)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Element_Url");
            });

            modelBuilder.Entity<Element_test>(entity =>
            {
                entity.HasKey(e => new { e.id_testcase, e.id_url, e.id_element })
                    .HasName("PK_Element_test_1");

                entity.HasOne(d => d.id_)
                    .WithMany(p => p.Element_test)
                    .HasForeignKey(d => new { d.id_testcase, d.id_url })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Element_test_Test_case");
            });

            modelBuilder.Entity<Form_elements>(entity =>
            {
                entity.HasKey(e => new { e.id_form, e.id_url });

                entity.HasOne(d => d.id_urlNavigation)
                    .WithMany(p => p.Form_elements)
                    .HasForeignKey(d => d.id_url)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Form_elements_Url");
            });

            modelBuilder.Entity<Input_elements>(entity =>
            {
                entity.HasKey(e => new { e.id_input, e.id_url })
                    .HasName("PK_Input_elements_1");

                entity.HasOne(d => d.id_urlNavigation)
                    .WithMany(p => p.Input_elements)
                    .HasForeignKey(d => d.id_url)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Input_elements_Url");
            });

            modelBuilder.Entity<Input_testcase>(entity =>
            {
                entity.HasKey(e => new { e.id_testcase, e.id_element, e.id_url });

                entity.HasOne(d => d.id_)
                    .WithMany(p => p.Input_testcase)
                    .HasForeignKey(d => new { d.id_element, d.id_url })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Input_testcase_Element");

                entity.HasOne(d => d.id_Navigation)
                    .WithMany(p => p.Input_testcase)
                    .HasForeignKey(d => new { d.id_testcase, d.id_url })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Input_testcase_Test_case1");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasOne(d => d.Id_UserNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.Id_User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_AspNetUsers");
            });

            modelBuilder.Entity<Redirect_url>(entity =>
            {
                entity.HasKey(e => new { e.id_testcase, e.id_url })
                    .HasName("PK_Redirect_url_1");

                entity.HasOne(d => d.id_)
                    .WithOne(p => p.Redirect_url)
                    .HasForeignKey<Redirect_url>(d => new { d.id_testcase, d.id_url })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Redirect_url_Test_case");
            });

            modelBuilder.Entity<Select_tag>(entity =>
            {
                entity.HasKey(e => new { e.id_select, e.id_url });

                entity.HasOne(d => d.id_urlNavigation)
                    .WithMany(p => p.Select_tag)
                    .HasForeignKey(d => d.id_url)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Select_tag_Url");
            });

            modelBuilder.Entity<Test_case>(entity =>
            {
                entity.HasKey(e => new { e.id_testcase, e.id_url })
                    .HasName("PK_Test_case_1");

                entity.HasOne(d => d.id_urlNavigation)
                    .WithMany(p => p.Test_case)
                    .HasForeignKey(d => d.id_url)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Test_case_Url");
            });

            modelBuilder.Entity<Url>(entity =>
            {
                entity.HasOne(d => d.project_)
                    .WithMany(p => p.Url)
                    .HasForeignKey(d => d.project_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Url_Project");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
