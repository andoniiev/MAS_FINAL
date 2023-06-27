using MasFinal.Models;

namespace MasFinal.Services
{
    /// <summary>
    /// Interface for company-related operations.
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Retrieves a list of employees working for the specified company.
        /// </summary>
        /// <param name="companyId">The ID of the company.</param>
        /// <returns>A list of employees working for the specified company.</returns>
        List<Employee> GetEmployeesByCompany(int companyId);
    }
}
