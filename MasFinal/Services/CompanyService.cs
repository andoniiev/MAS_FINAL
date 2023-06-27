using MasFinal.Data;
using MasFinal.Models;

namespace MasFinal.Services
{
    /// <summary>
    /// Service for managing company-related operations.
    /// </summary>
    public class CompanyService : ICompanyService
    {
        private readonly MasFinalContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CompanyService(MasFinalContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves a list of employees belonging to the specified company.
        /// </summary>
        /// <param name="companyId">The ID of the company.</param>
        /// <returns>A list of employees associated with the company.</returns>
        public List<Employee> GetEmployeesByCompany(int companyId)
        {
            if (companyId <= 0)
            {
                return new List<Employee>();
            }
            else
                return _dbContext.Employees
                .Where(e => e.CompanyId == companyId)
                .ToList();
        }
    }
}
