using DDFinanceBackend.Models.Requests;
using FluentValidation;

namespace DDFinanceBackend.Validation
{
    public class DeleteInsurancePoliciesRequestValidation : AbstractValidator<DeleteInsurancePoliciesRequest>
    {
        public DeleteInsurancePoliciesRequestValidation()
        {
            RuleFor(r => r.PolicyId)
                .GreaterThan(0).WithMessage("Policy ID must be greater than 0.");
        }
    }
}
