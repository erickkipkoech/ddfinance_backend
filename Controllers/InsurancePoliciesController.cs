using DDFinanceBackend.Models.Requests;
using DDFinanceBackend.Repository;
using Microsoft.AspNetCore.Mvc;
using DDFinanceBackend.Models.Responses;

namespace DDFinanceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly IInsurancePolicies _repository;

        public InsurancePoliciesController(IInsurancePolicies repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllInsurancePolicies")]
        public async Task<ActionResult<IEnumerable<InsurancePolicies>>> GetAllInsurancePolicies()
        {
            var policies = await _repository.GetAllInsurancePoliciesAsync();
            var response = new MainResponse<IEnumerable<InsurancePolicies>>(policies);
            return Ok(response);
        }

        [HttpGet("GetInsurancePoliciesById/{PolicyId}")]
        public async Task<ActionResult<InsurancePolicies>> GetInsurancePoliciesById([FromRoute] GetInsurancePoliciesByIdRequest request)
        {
             MainResponse<InsurancePolicies> response;
            var policy = await _repository.GetInsurancePoliciesByIdAsync(request);
            if (policy == null)
            {
                 response = new MainResponse<InsurancePolicies>(null, "Policy not found.");
                return NotFound(response);
            }

             response = new MainResponse<InsurancePolicies>(policy);
            return Ok(response);
        }

        [HttpPost("AddInsurancePolicies")]
        public async Task<ActionResult<InsurancePolicies>> AddInsurancePolicies(AddEditInsurancePoliciesRequest request)
        {
            MainResponse<InsurancePolicies> response;
            var policy = await _repository.AddInsurancePoliciesAsync(request);
            if (policy == null || string.IsNullOrEmpty(policy.PolicyId.ToString()))
            {
                response = new MainResponse<InsurancePolicies>(null, "Failed to add the policy.");
                return BadRequest(response);
            }

            response = new MainResponse<InsurancePolicies>(policy);
            return CreatedAtAction(nameof(GetInsurancePoliciesById), new { PolicyId = policy.PolicyId }, response);
        }

        [HttpPut("UpdateInsurancePolicies")]
        public async Task<IActionResult> UpdateInsurancePolicies(AddEditInsurancePoliciesRequest request)
        {
            MainResponse<InsurancePolicies> response;
            var updatedPolicy = await _repository.UpdateInsurancePoliciesAsync(request);
            if (updatedPolicy == null)
            {
                response = new MainResponse<InsurancePolicies>(null, "Policy not found.");
                return NotFound(response);
            }

            response = new MainResponse<InsurancePolicies>(updatedPolicy);
            return Ok(response);
        }

        [HttpDelete("DeleteInsurancePolicies")]
        public async Task<IActionResult> DeleteInsurancePolicies(DeleteInsurancePoliciesRequest request, CancellationToken cancellationToken)
        {
            MainResponse<InsurancePolicies> response;
            var success = await _repository.DeleteInsurancePoliciesAsync(request, cancellationToken);
            if (!success)
            {
                response = new MainResponse<InsurancePolicies>(null, "Policy not found.");
                return NotFound(response);
            }

            response = new MainResponse<InsurancePolicies>(null);
            return Ok();
        }
    }
}
