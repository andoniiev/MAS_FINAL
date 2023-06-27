using MasFinal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MasFinal.Data
{
    /// <summary>
    /// Represents the database context for the MasFinal application.
    /// </summary>
    public class MasFinalContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the MasFinalContext class with the specified options.
        /// </summary>
        /// <param name="options">The options for configuring the context.</param>
        public MasFinalContext(DbContextOptions<MasFinalContext> options) : base(options)
        { }

        /// <summary>
        /// Gets or sets the collection of Employee entities.
        /// </summary>
        public DbSet<Employee> Employees { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of Company entities.
        /// </summary>
        public DbSet<Company> Companies { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of Skill entities.
        /// </summary>
        public DbSet<Skill> Skills { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of Certification entities.
        /// </summary>
        public DbSet<Certification> Certifications { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of EmployeeCertification entities.
        /// </summary>
        public DbSet<EmployeeCertification> EmployeeCertifications { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of Experience entities.
        /// </summary>
        public DbSet<Experience> Experiences { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of Posting entities.
        /// </summary>
        public DbSet<Posting> Postings { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of JobPosting entities.
        /// </summary>
        public DbSet<JobPosting> JobPostings { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of JobApplication entities.
        /// </summary>
        public DbSet<JobApplication> JobApplications { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of Recruiter entities.
        /// </summary>
        public DbSet<Recruiter> Recruiters { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of Payment entities.
        /// </summary>
        public DbSet<Payment> Payments { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of Education entities.
        /// </summary>
        public DbSet<Education> Educations { get; set; } = null!;

        /// <summary>
        /// Configures the database model for the context.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for the context being created.</param>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("People");

                entity.HasKey(e => e.Id);



                entity.Property(e => e.Pesel)
                    .HasColumnName("Pesel")
                    .IsRequired()
                    .HasAnnotation("RegularExpression", @"^[0-9]{2}([02468]1|[13579][012])(0[1-9]|1[0-9]|2[0-9]|3[01])[0-9]{5}$");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasAnnotation("RegularExpression", @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasAnnotation("RegularExpression", @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");

                entity.Property(e => e.Sex)
                    .HasColumnName("Sex")
                    .IsRequired();

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("DateOfBirth")
                    .IsRequired()
                    .HasAnnotation("CheckDateOfBirth", "DateOfBirth <= GETDATE()");
            });

            modelBuilder.Entity<Employee>()
              .HasBaseType<Person>();

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");



                entity.HasOne(e => e.Company)
                    .WithMany()
                    .HasForeignKey(e => e.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.CV)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Recruiter>()
             .HasBaseType<Person>();

            modelBuilder.Entity<Recruiter>(entity =>
            {
                entity.ToTable("Recruiters");



                entity.HasOne(r => r.OwnedCompany)
                    .WithOne()
                    .HasForeignKey<Recruiter>(r => r.OwnedCompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.CurrentCompany)
                    .WithOne()
                    .HasForeignKey<Recruiter>(r => r.CurrentCompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(r => r.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(r => r.ContactPhone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(r => r.RecruiterType)
                    .IsRequired();

                entity.HasMany(r => r.JobPostings)
                    .WithOne(j => j.Recruiter)
                    .HasForeignKey(j => j.RecruiterId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("Certifications");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(c => c.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Organisation)
                    .HasColumnName("Organisation")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Category)
                    .HasColumnName("Category")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Companies");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();


                entity.Property(c => c.CompanyName)
                    .HasColumnName("CompanyName")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.YearFounded)
                    .HasColumnName("YearFounded")
                    .IsRequired();

                entity.Property(c => c.CompanySite)
                    .HasColumnName("CompanySite")
                    .HasMaxLength(100);



                entity.HasMany(c => c.Postings)
                    .WithOne(p => p.Company)
                    .HasForeignKey(p => p.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Educations");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100);

                

                 entity.HasMany(emps => emps.EmployeeList)
                .WithMany(sk => sk.Educations)
                .UsingEntity(s => s.ToTable("EducationEmployee"));
            });

            modelBuilder.Entity<EmployeeCertification>(entity =>
            {
                entity.ToTable("EmployeeCertifications");

                entity.HasKey(ec => ec.Id);

                entity.Property(ec => ec.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(ec => ec.AcquisitonDate)
                    .HasColumnName("AcquisitionDate")
                    .IsRequired();

                entity.Property(ec => ec.ValidUntil)
                    .HasColumnName("ValidUntil")
                    .IsRequired();

                entity.HasOne(ec => ec.Employee);

                entity.HasOne(ec => ec.Certification)
                    .WithMany()
                    .HasForeignKey(ec => ec.CertificationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skills");

                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(s => s.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(s => s.Description)
                    .HasColumnName("Description")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(s => s.Category)
                    .HasColumnName("Category")
                    .IsRequired()
                    .HasMaxLength(100);
                entity
                .HasMany(emps => emps.EmployeeList)
                .WithMany(sk => sk.SkillList)
                .UsingEntity(s => s.ToTable("SkillEmployee"));
            });

            modelBuilder.Entity<Posting>(entity =>
            {
                entity.ToTable("Postings");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(p => p.PostingTime)
                    .HasColumnName("PostingTime")
                    .IsRequired();

                entity.Property(p => p.PostingText)
                    .HasColumnName("PostingText")
                    .IsRequired();

                entity.Property(p => p.CompanyId)
                    .HasColumnName("CompanyId")
                    .IsRequired();

                entity.HasOne(p => p.Company)
                    .WithMany(c => c.Postings)
                    .HasForeignKey(p => p.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(p => p.Amount)
                    .HasColumnName("Amount")
                    .IsRequired();

                entity.Property(p => p.PayerName)
                    .HasColumnName("PayerName")
                    .HasMaxLength(100);

                entity.Property(p => p.PayerEmail)
                    .HasColumnName("PayerEmail")
                    .HasMaxLength(100);

                entity.Property(p => p.CreditNumber)
                    .HasColumnName("CreditNumber")
                    .HasMaxLength(100);

                entity.Property(p => p.CardBalance)
                    .HasColumnName("CardBalance");

                entity.Property(p => p.BankName)
                    .HasColumnName("BankName")
                    .HasMaxLength(100);

                entity.Property(p => p.AccountNumber)
                    .HasColumnName("AccountNumber")
                    .HasMaxLength(100);

                entity.Property(p => p.AccountBalance)
                    .HasColumnName("AccountBalance");

                entity.Property(p => p.PaymentType)
                    .HasColumnName("PaymentType")
                    .IsRequired();


                entity.Property(p => p.PaymentType)
                    .HasConversion<string>();
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experiences");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StartTime)
                    .HasColumnName("StartTime")
                    .IsRequired();

                entity.Property(e => e.EndTime)
                    .HasColumnName("EndTime")
                    .IsRequired();

                entity.Property(e => e.Position)
                    .HasColumnName("Position")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyId")
                    .IsRequired();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeId")
                    .IsRequired();

                entity.HasOne(e => e.Company)
                    .WithMany()
                    .HasForeignKey(e => e.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Employee)
                    .WithMany(e => e.ExperienceList)
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<JobApplication>(entity =>
            {
                entity.ToTable("JobApplications");

                entity.HasKey(j => j.Id);

                entity.Property(j => j.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(j => j.ApplicationDate)
                    .HasColumnName("ApplicationDate")
                    .IsRequired();

                entity.Property(j => j.Status)
                    .HasColumnName("Status")
                    .IsRequired();

                entity.Property(j => j.Comments)
                    .HasColumnName("Comments")
                    .HasMaxLength(100);

                entity.Property(j => j.ApplicantId)
                    .HasColumnName("ApplicantId")
                    .IsRequired();

                entity.Property(j => j.JobPostingId)
                    .HasColumnName("JobPostingId")
                    .IsRequired();

                entity.HasOne(j => j.Applicant);



                entity.HasOne(j => j.JobPosting)
                    .WithMany(jp => jp.JobApplications)
                    .HasForeignKey(j => j.JobPostingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<JobPosting>(entity =>
            {
                entity.ToTable("JobPostings");

                entity.HasKey(j => j.Id);

                entity.Property(e => e.DatePosted)
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(j => j.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(j => j.Title)
                    .HasColumnName("Title")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(j => j.Description)
                    .HasColumnName("Description")
                    .IsRequired();

                entity.Property<int>("MaxDaysPosted")
                    .HasColumnName("MaxDaysPosted")
                    .HasDefaultValue(JobPosting.MaxDaysPosted);

                entity.Property(j => j.RecruiterId)
                    .HasColumnName("RecruiterId")
                    .IsRequired();

                entity.Property(j => j.CompanyId)
                    .HasColumnName("CompanyId")
                    .IsRequired();

                entity.HasOne(j => j.Recruiter)
                    .WithMany(r => r.JobPostings)
                    .HasForeignKey(j => j.RecruiterId)
                    .OnDelete(DeleteBehavior.Cascade);



                entity.HasMany(j => j.RequiredSkills)
                    .WithMany();
            });

        }

        /// <summary>
        /// Configures the options for the context.
        /// </summary>
        /// <param name="optionsBuilder">The builder used to create or modify options for this context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=masfinal.db");
        }
    }
}
