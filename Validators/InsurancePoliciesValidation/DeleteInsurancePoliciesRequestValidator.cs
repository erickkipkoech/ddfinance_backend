using DDFinanceBackend.Models.Requests;
using FluentValidation;

namespace DDFinanceBackend.Validation
{
    public class DeleteInsurancePoliciesRequestValidation : AbstractValidator<DeleteInsurancePoliciesRequest>
    {
        public DeleteInsurancePoliciesRequestValidation()
        {
            RuleFor(x => x.PolicyIds)
               .NotNull().WithMessage("PolicyIds cannot be null")
               .NotEmpty().WithMessage("At least one PolicyId is required")
               .Must(policyIds => policyIds.All(id => id > 0)).WithMessage("Each PolicyId must be greater than 0");
        }
    }
}
