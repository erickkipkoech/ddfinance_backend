using DDFinanceBackend.Models;
using DDFinanceBackend.Models.Requests;

namespace DDFinanceBackend.Repository
{
    public interface IInsurancePolicies
    {
        Task<IEnumerable<InsurancePolicies>> GetAllInsurancePoliciesAsync();

        Task<InsurancePolicies?> GetInsurancePoliciesByIdAsync(GetInsurancePoliciesByIdRequest getInsurancePoliciesByIdRequest);

        Task<InsurancePolicies> AddInsurancePoliciesAsync(AddEditInsurancePoliciesRequest addEditInsurancePoliciesRequest);

        Task<InsurancePolicies?> UpdateInsurancePoliciesAsync(AddEditInsurancePoliciesRequest addEditInsurancePoliciesRequest);

        Task<bool> DeleteInsurancePoliciesAsync(DeleteInsurancePoliciesRequest deleteInsurancePoliciesRequest, CancellationToken cancellationToken);
    }
}
