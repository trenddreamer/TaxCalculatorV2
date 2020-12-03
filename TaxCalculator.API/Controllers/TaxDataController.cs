using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculator.API.Repository.IRepository;
using TaxCalculator.Models.Calculator;
using TaxCalculator.Models.Entities;

namespace TaxCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TaxDataController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public TaxDataController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get list of Postal Codes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PostalCode>))]
        public IActionResult GetPostalCodes()
        {
            var data = _unitOfWork.PostalCode.GetAll();
            return Ok(data);
        }

        /// <summary>
        /// Get a Tax Result record.
        /// </summary>
        /// <param name="taxResultID"> The Id of the TaxResult  </param>
        /// <returns></returns>
        [HttpGet("[action]/{taxResultID:int}", Name = "GetTaxResult")]
        [ProducesResponseType(200, Type = typeof(TaxResult))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        [Authorize]
        public IActionResult GetTaxResult(int taxResultID)
        {
            var data = _unitOfWork.TaxResult.Get(taxResultID);
            return Ok(data);
        }
        /// <summary>
        /// Create a Tax result record
        /// </summary>
        /// <param name="taxResult"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TaxResult))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult SaveTaxResult([FromBody] TaxResult taxResult)
        {
            if (taxResult == null)
            {
                return BadRequest(ModelState);
            }
            var ratesData = _unitOfWork.ProgressiveTaxRate.GetAll(orderBy: q => q.OrderBy(s => s.LowBand));

            var taxCalculator = new Calculator(taxResult.Amount, ratesData);

            var taxType = _unitOfWork.TaxType_PostalCode_Ref.GetFirstOrDefault(t => t.PostalCodeID == taxResult.PostalCodeID, "TaxType").TaxType;

            decimal TaxAmount = 0;
           
            //I wouldnt normally hardcode strings for comparison like this but for this small project it serves the purpose.
            switch (taxType.Description)
            {
                case "Progressive":
                    TaxAmount = taxCalculator.CalculateProgressiveTax();
                    break;
                case "Flat Value":
                    TaxAmount = taxCalculator.CalulateFlatValueTax();
                    break;
                case "Flat Rate":
                    TaxAmount = taxCalculator.CalculateFlatRateTax();
                    break;
                default:
                    break;
            }

            taxResult.TaxAmount = TaxAmount;
            taxResult.CreatedDate = DateTime.Now;
            _unitOfWork.TaxResult.Add(taxResult);

            //Checking if the save method return true or false
            if (!_unitOfWork.Save())
            {
                ModelState.AddModelError("", $"There was an error when saving the tax for {taxResult.Amount}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetTaxResult", new {version=HttpContext.GetRequestedApiVersion().ToString(), taxResultID = taxResult.Id }, taxResult);
        }

    }
}
