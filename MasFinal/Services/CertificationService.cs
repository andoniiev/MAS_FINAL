using MasFinal.Data;
using MasFinal.Models;

namespace MasFinal.Services
{
    /// <summary>
    /// Service for managing certifications and related operations.
    /// </summary>
    public class CertificationService : ICertificationService
    {
        private readonly MasFinalContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificationService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CertificationService(MasFinalContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves a list of employees who are certified with the specified certification.
        /// </summary>
        /// <param name="certificationId">The ID of the certification.</param>
        /// <returns>A list of certified employees.</returns>
        public List<Employee> GetCertifiedUsers(int certificationId)
        {
            return _dbContext.EmployeeCertifications
                .Where(ec => ec.CertificationId == certificationId)
                .Select(ec => ec.Employee)
                .ToList();
        }

        /// <summary>
        /// Retrieves a list of employees who have a certification that is not currently valid.
        /// </summary>
        /// <param name="certificationId">The ID of the certification.</param>
        /// <returns>A list of employees with expired or invalid certifications.</returns>
        public List<Employee> FindUsersWithNotValidCertification(int certificationId)
        {
            var today = DateTime.Today;
            if (certificationId <= 0)
            {
                return new List<Employee>();
            }
            else
                return _dbContext.EmployeeCertifications
                .Where(ec => ec.CertificationId == certificationId && ec.ValidUntil < today)
                .Select(ec => ec.Employee)
                .ToList();
        }
    }
}
