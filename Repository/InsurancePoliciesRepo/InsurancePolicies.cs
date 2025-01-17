using DDFinanceBackend.Data;
using DDFinanceBackend.Models;
using DDFinanceBackend.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace DDFinanceBackend.Repository
{
    public class InsurancePoliciesRepository : IInsurancePolicies
    {
        private readonly AppDbContext _context;

        public InsurancePoliciesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InsurancePolicies>> GetAllInsurancePoliciesAsync()
        {
            return await _context.InsurancePolicies.ToListAsync();
        }

        public async Task<InsurancePolicies?> GetInsurancePoliciesByIdAsync(GetInsurancePoliciesByIdRequest request)
        {
            return await _context.InsurancePolicies.FindAsync(request.PolicyId);
        }

        public async Task<InsurancePolicies> AddInsurancePoliciesAsync(AddEditInsurancePoliciesRequest request)
        {
            var policy = new InsurancePolicies
            {
                PolicyName = request.PolicyName,
                PremiumAmount = request.PremiumAmount,
                PolicyType = request.PolicyType,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            _context.InsurancePolicies.Add(policy);
            await _context.SaveChangesAsync();
            return policy;
        }

        public async Task<InsurancePolicies?> UpdateInsurancePoliciesAsync(AddEditInsurancePoliciesRequest request)
        {
            var existingPolicy = await _context.InsurancePolicies
                .FirstOrDefaultAsync(p => p.PolicyId == request.PolicyId);

            if (existingPolicy == null)
                return null;

            existingPolicy.PremiumAmount = request.PremiumAmount;
            existingPolicy.PolicyType = request.PolicyType;
            existingPolicy.StartDate = request.StartDate;
            existingPolicy.EndDate = request.EndDate;

            await _context.SaveChangesAsync();
            return existingPolicy;
        }

        public async Task<bool> DeleteInsurancePoliciesAsync(DeleteInsurancePoliciesRequest request, CancellationToken cancellationToken)
        {
            if (request?.PolicyIds == null || !request.PolicyIds.Any())
            {
                return false;
            }
            var policiesToDelete = await _context.InsurancePolicies
                                        .Where(policy => request.PolicyIds.Contains(policy.PolicyId))
                                        .ToListAsync(cancellationToken);
            // Console.WriteLine(policy);
            if (!policiesToDelete.Any())
            {
                return false;
            }

            _context.InsurancePolicies.RemoveRange(policiesToDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
