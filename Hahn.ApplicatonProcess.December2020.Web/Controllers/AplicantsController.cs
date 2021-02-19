using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Web.Examples;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicantsController : ControllerBase
    {
        public ILogger<AplicantsController> _logger { get; }
        public IApplicantService _applicantService { get; }

        public AplicantsController(ILogger<AplicantsController> logger, IApplicantService applicant)
        {
            _logger = logger;
            _applicantService = applicant;
        }

        [HttpGet]
        [SwaggerResponse(201, type: typeof(List<Applicant>))]
        [SwaggerResponseExample(201, typeof(ApplicantsResponseExample))]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting applicant list.");
            return Ok(_applicantService.GetList());
        }

        /// <param name="id" example="1">id</param>
        [HttpGet("{id}")]
        [SwaggerResponse(201, type: typeof(Applicant))]
        [SwaggerResponseExample(201, typeof(ApplicantResponseExample))]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Getting applicant by id.", id);
            return Ok(_applicantService.GetById(id));
        }

        /// <summary>
        /// Creates Applicant.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A newly created Applicant</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(typeof(Applicant), 201)]
        [SwaggerRequestExample(typeof(Applicant), typeof(ApplicantRequestExample))]
        [SwaggerResponseExample(201, typeof(ApplicantRequestExample))]
        public IActionResult Post([FromBody] Applicant item)
        {
            if (item == null) return BadRequest();
            _logger.LogInformation("Adding new applicant to list.", item);
            _applicantService.Add(item);
            return Ok(item);
        }

        /// <summary>
        /// Updates Applicant.
        /// </summary>
        /// <param name="item"></param>
        ///  <param name="id" example="1">id</param>
        /// <returns>Updated Applicant</returns>
        /// <response code="201"></response>
        /// <response code="400">If the item is null</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), 201)]
        [SwaggerRequestExample(typeof(Applicant), typeof(ApplicantRequestExample))]
        public IActionResult Put(int id, [FromBody] Applicant item)
        {
            if (item == null) return BadRequest();
            _logger.LogInformation("Editing applicant.", item);
            _applicantService.Update(id, item);
            return Ok();
        }

        /// <summary>
        /// Deletes a specific Applicant.
        /// </summary>
        ///  <param name="id" example="1">id</param>
        /// <response code="201"></response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 201)]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Removing applicant from list.", id);
            _applicantService.Delete(id);
            return Ok();
        }
    }
}
