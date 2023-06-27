using MasFinal.Data;
using MasFinal.Models;
using MasFinal.Services;
using MasFinal.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

/// <summary>
/// Provides methods to initialize the data in the MasFinalContext.
/// </summary>
public static class DataInitializer
{
    /// <summary>
    /// Initializes the data in the MasFinalContext.
    /// </summary>
    /// <param name="context">The MasFinalContext instance.</param>
    public static void Initialize(MasFinalContext context)
    {

        using (context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            #region Create initial records


            // Create skills
            var skills = new List<Skill>
        {
            new Skill { Name = "ASP.NET", Description = "Web Framework", Category = "Programming" },
            new Skill { Name = "C#", Description = "Programming Language", Category = "Programming" },
            new Skill { Name = "AWS", Description = "Cloud Service", Category = "Cloud" },
            new Skill { Name = "Azure", Description = "Cloud Service", Category = "Cloud" },
            new Skill { Name = "JavaScript", Description = "Same as Java", Category = "Programming" },

        };
            context.Skills.AddRange(skills);
            context.SaveChanges();

            // Create certifications
            var educations = new List<Education>
        {
            new Education { Name = "Polsko-Japonska Akademia Technik Komputerowych"},
            new Education {Name = "Uniwersytet Warszawski"},
            new Education {Name = "Vistula"},
            new Education {Name = "Politechnika Warszawska"},

        };
            context.Educations.AddRange(educations);
            context.SaveChanges();

            // Create companies
            var companies = new List<Company>
        {
            new Company { CompanyName = "Google", YearFounded = 1999, CompanySite = "www.google.com" },
            new Company { CompanyName = "Facebook", YearFounded = 2005, CompanySite = "www.facebook.com" },
            new Company { CompanyName = "Amazon", YearFounded = 1997, CompanySite = "www.amazon.com" },
            new Company { CompanyName = "Apple", YearFounded = 2002, CompanySite = "www.apple.com" },

        };
            context.Companies.AddRange(companies);
            context.SaveChanges();

            // Create recruiters
            var recruiters = new List<Recruiter>
        {
            new Recruiter
            {
                FirstName = "Sam",
                LastName = "Johnson",
                ContactEmail = "sam.jonshon@google.com",
                ContactPhone = "+48-555-333-888",
                OwnedCompany = null,
                CurrentCompany = companies[0],
                RecruiterType = RecruiterType.Recruiter
            },
            new Recruiter
            {
                FirstName = "Emmy",
                LastName = "Watson",
                ContactEmail = "emmy.watson@apple.com",
                ContactPhone = "987654321",
                OwnedCompany = companies[1],
                CurrentCompany = companies[1],
                RecruiterType = RecruiterType.RecruiterOwner
            },
            // Add more recruiters as needed
        };
            context.Recruiters.AddRange(recruiters);
            context.SaveChanges();

            // Create employees
            var employees = new List<Employee>
        {
            new Employee
            {
                FirstName = "Steve",
                LastName = "Jobs",
                Company = companies[0],
                SkillList = new List<Skill> { skills[0], skills[1], skills[4] },
                Educations = new List<Education>{educations[0]},
                CV = "Data\\Pdf\\Resume1.pdf"
            },
           new Employee
            {
                FirstName = "Pete",
                LastName = "Davidson",
                Company = companies[1],
                SkillList = new List<Skill> { skills[0], skills[2] },
                Educations = new List<Education>{educations[1], educations[2] },
                CV = "Data\\Pdf\\Resume2.pdf"
           },
           new Employee
            {
                FirstName = "Guy",
                LastName = "Ritchie",
                Company = companies[2],
                SkillList = new List<Skill> { skills[1], skills[3] },
                Educations = new List<Education>{educations[3]},
                CV = "Data\\Pdf\\Resume3.pdf"
            },
           new Employee
            {
                FirstName = "Hugh",
                LastName = "Jackman",
                Company = companies[3],
                SkillList = new List<Skill> { skills[0], skills[1], skills[2] },
                Educations = new List<Education>{},
                 CV = "Data\\Pdf\\Resume4.pdf"
            },
           new Employee
            {
                FirstName = "Mad",
                LastName = "Dimon",
                Company = null,
                SkillList = new List<Skill> { skills[0], skills[1], skills[2], skills[3] },
                Educations = new List<Education>{educations[1], educations[0], educations[2] },
                 CV = "Data\\Pdf\\Resume5.pdf"
           }
        };
            context.Employees.AddRange(employees);
            context.SaveChanges();


            var jobPostings = new List<JobPosting>
        {
            new JobPosting
            {
                Title = "Senior Dev",
                Description = "We are looking for an experienced .NET Developer.\n At least 5 years in .NET\n Salary 20000 + VAT",
                RequiredSkills = new List<Skill> { skills[0], skills[1] },
                Recruiter = recruiters[0],
                Company = companies[0],
                DatePosted = DateTime.Now.AddDays(-7),

            },
            new JobPosting
            {
                Title = "Middle Dev",
                Description = "We are looking for an experienced .NET Developer.\n At least 3 years in .NET\nExperience in AWS would be nice\n Salary 13000 + VAT",
                RequiredSkills = new List<Skill> { skills[0], skills[3] },
                Recruiter = recruiters[0],
                Company = companies[0],
                DatePosted = DateTime.Now.AddDays(-7)
            },
            new JobPosting
            {
                Title = "Junior Dev",
                Description = "We are looking for a new .NET Developer.\n Commercial experience is not required but would be nice\n Salary 5000 - UZ",
                RequiredSkills = new List<Skill> { skills[0], skills[1] },
                Recruiter = recruiters[0],
                Company = companies[1],
                DatePosted = DateTime.Now.AddDays(-17)
            },
            new JobPosting
            {
                Title = "Middle Dev",
                Description = "We are looking for an experienced .NET Developer.\n At least 4 years in .NET\nExperience in Azure would be nice\n Salary 13000 + VAT",
                RequiredSkills = new List<Skill> { skills[0], skills[3] },
                Recruiter = recruiters[0],
                Company = companies[1],
                DatePosted = DateTime.Now.AddDays(-5)
            },

            new JobPosting
            {
                Title = "Senior Dev",
                Description = "We are looking for an experienced .NET Developer.\n At least 5 years in .NET\n Salary 20000 + VAT",
                RequiredSkills = new List<Skill> { skills[0], skills[1] },
                Recruiter = recruiters[0],
                Company = companies[3],
                DatePosted = DateTime.Now.AddDays(-7)
            },
            new JobPosting
            {
                Title = "Middle Dev",
                Description = "We are looking for a middle .NET/Javascript Developer.\n At least 3 years in .NET\nKnowledge of React would be nice\n Salary 10000 + VAT",
                RequiredSkills = new List<Skill> { skills[0], skills[4] },
                Recruiter = recruiters[1],
                Company = companies[3],
                DatePosted = DateTime.Now.AddDays(-5)
            },
            new JobPosting
            {
                Title = "AWS Admin",
                Description = "We are looking for an experienced AWS Admin.\n 7+ years in administratinf aws infrastructure\n Salary 17000 + VAT",
                RequiredSkills = new List<Skill> { skills[4], skills[0], skills[2] },
                Recruiter = recruiters[0],
                Company = companies[2],
                DatePosted = DateTime.Now.AddDays(-13)
            },
            new JobPosting
            {
                Title = "Intern Dev",
                Description = "We are looking for an intern .NET Developer.\n Knowledge of .NET\nExperience with Entity Framework\n Salary 6000 - UZ",
                RequiredSkills = new List<Skill> { skills[0], skills[4], skills[1] },
                Recruiter = recruiters[0],
                Company = companies[2],
                DatePosted = DateTime.Now.AddDays(-5)
            },
        };
            context.JobPostings.AddRange(jobPostings);
            context.SaveChanges();

            // Create job applications
            var jobApplications = new List<JobApplication>
        {
            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-1),
                Status = StatusType.Processing,
                Applicant = employees[0],
                JobPosting = jobPostings[0]
            },
            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-10),
                Status = StatusType.Processing,
                Comments = "Left for review",
                Applicant = employees[1],
                JobPosting = jobPostings[1]
            },

            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-1),
                Status = StatusType.Processing,
                Applicant = employees[2],
                JobPosting = jobPostings[0]
            },
            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-10),
                Status = StatusType.Processing,
                Comments = "Left for review",
                Applicant = employees[3],
                JobPosting = jobPostings[1]
            },

            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-1),
                Status = StatusType.Processing,
                Applicant = employees[3],
                JobPosting = jobPostings[2]
            },
            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-10),
                Status = StatusType.Processing,
                Comments = "Left for review",
                Applicant = employees[4],
                JobPosting = jobPostings[2]
            },

            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-1),
                Status = StatusType.Processing,
                Applicant = employees[0],
                JobPosting = jobPostings[5]
            },
            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-10),
                Status = StatusType.Processing,
                Comments = "Left for review",
                Applicant = employees[0],
                JobPosting = jobPostings[3]
            },

            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-1),
                Status = StatusType.Processing,
                Applicant = employees[1],
                JobPosting = jobPostings[4]
            },
            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-10),
                Status = StatusType.Processing,
                Comments = "Left for review",
                Applicant = employees[3],
                JobPosting = jobPostings[6]
            },

            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-1),
                Status = StatusType.Processing,
                Applicant = employees[4],
                JobPosting = jobPostings[0]
            },
            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-10),
                Status = StatusType.Processing,
                Comments = "Left for review",
                Applicant = employees[4],
                JobPosting = jobPostings[7]
            },

            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-1),
                Status = StatusType.Processing,
                Applicant = employees[2],
                JobPosting = jobPostings[5]
            },
            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-10),
                Status = StatusType.Processing,
                Comments = "Left for review",
                Applicant = employees[1],
                JobPosting = jobPostings[3]
            },

            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-1),
                Status = StatusType.Processing,
                Applicant = employees[3],
                JobPosting = jobPostings[0]
            },
            new JobApplication
            {
                ApplicationDate = DateTime.Now.AddDays(-10),
                Status = StatusType.Processing,
                Comments = "Left for review",
                Applicant = employees[4],
                JobPosting = jobPostings[1]
            },

        };
            context.JobApplications.AddRange(jobApplications);
            context.SaveChanges();


            // Create certifications
            var certifications = new List<Certification>
        {
            new Certification { Name = "AWS certification", Organisation = "AWS", Category = "Cloud" },
            new Certification { Name = "Azure certification", Organisation = "Microsoft", Category = "Cloud" },
            new Certification { Name = ".NET certification", Organisation = "Microsoft", Category = "Programming" },
            new Certification { Name = "Front-End certification", Organisation = "Oracle", Category = "Programming" },

        };
            context.Certifications.AddRange(certifications);
            context.SaveChanges();

            //create EmployeeCertifications
            var employeeCertifications = new List<EmployeeCertification>
        {
            new EmployeeCertification { Certification = certifications[0], Employee = employees[0], AcquisitonDate = DateTime.Now.AddDays(-15), ValidUntil  = DateTime.Now.AddYears(2) },
            new EmployeeCertification { Certification = certifications[1], Employee = employees[0], AcquisitonDate = DateTime.Now.AddDays(-25), ValidUntil  = DateTime.Now.AddYears(5) },
            new EmployeeCertification { Certification = certifications[2], Employee = employees[0], AcquisitonDate = DateTime.Now.AddDays(-20), ValidUntil  = DateTime.Now.AddYears(10) },
            new EmployeeCertification { Certification = certifications[0], Employee = employees[1], AcquisitonDate = DateTime.Now.AddDays(-10), ValidUntil  = DateTime.Now.AddYears(1) },
            new EmployeeCertification { Certification = certifications[0], Employee = employees[2], AcquisitonDate = DateTime.Now.AddDays(-12), ValidUntil  = DateTime.Now.AddYears(3) },
            new EmployeeCertification { Certification = certifications[0], Employee = employees[3], AcquisitonDate = DateTime.Now.AddDays(-11), ValidUntil  = DateTime.Now.AddYears(4) },
            new EmployeeCertification { Certification = certifications[2], Employee = employees[2], AcquisitonDate = DateTime.Now.AddDays(-13), ValidUntil  = DateTime.Now.AddYears(1) },
        };
            context.EmployeeCertifications.AddRange(employeeCertifications);
            context.SaveChanges();


            #endregion



        }
    }
}

