using DDFinanceBackend.Models.Requests;
using FluentValidation;

namespace DDFinanceBackend.Validation
{
    public class AddEditInsurancePoliciesRequestValidation : AbstractValidator<AddEditInsurancePoliciesRequest>
    {
        public AddEditInsurancePoliciesRequestValidation()
        {
            RuleFor(r => r.PolicyName)
                .NotEmpty().WithMessage("Policy name is required.")
                .MaximumLength(100).WithMessage("Policy name cannot exceed 100 characters.");

            RuleFor(r => r.PremiumAmount)
                .GreaterThan(0).WithMessage("Premium amount must be greater than 0.");

            RuleFor(r => r.PolicyType)
                .NotEmpty().WithMessage("Policy type is required.");

            RuleFor(r => r.StartDate)
                .LessThan(r => r.EndDate).WithMessage("Start date must be before end date.");
        }
    }
}
