using InterestApi.Abstract.Validation;
using InterestApi.Concrete.Validation;
using InterestApi.Entities;
using InterestApi.Helpers;
using InterestApi.Requests;
using InterestApi.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InterestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        private readonly InterestsOptions _interestOptions;
        public InterestsController(IConfiguration configuration)
        {
            _interestOptions = configuration.GetSection("InterestsOptions").Get<InterestsOptions>();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Calculate([FromBody] InterestRequest request)
        {
            var result = ValidationResult(request);
            if (result != null)
                return BadRequest(result);
            var response = CalculateInterest(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PaymentPlan([FromBody] InterestRequest request)
        {
            var result = ValidationResult(request);
            if (result != null)
                return BadRequest(result);
            var response = CalculateInterest(request);
            return Ok();
        }

        private CalculateInterestResponse CalculateInterest(InterestRequest request)
        {
            double totalPrice = request.DesiredAmount + (request.DesiredAmount * _interestOptions.InterestRate / 100 * request.MaturityAmount);
            return new CalculateInterestResponse
            {
                TotalPaymentAmount = totalPrice,
                TotalInterestAmount = totalPrice - request.DesiredAmount
            };
        }

        /// <summary>
        /// Validasyonları tek bir yerden yönetebilmek için oluşturulan fonksiyon
        /// </summary>
        /// <param name="request">Parametrelerin geleceği nesne</param>
        /// <returns></returns>
        private IValidationResult ValidationResult(InterestRequest request)
        {
            return ValidationHelper.Run(
                CheckNullDesiredAmount(request.DesiredAmount),
                CheckNegativeDesiredAmount(request.DesiredAmount),
                CheckNullMaturityAmount(request.MaturityAmount),
                CheckNegativeMaturityAmount(request.MaturityAmount),
                CheckMinDesiredAmount(request.DesiredAmount));
        }

        /// <summary>
        /// İstenen miktar null veya sıfır ise hata döndürür
        /// </summary>
        /// <param name="desiredAmount">İstenen Miktar</param>
        /// <returns></returns>
        private IValidationResult CheckNullDesiredAmount(int desiredAmount)
        {
            if (desiredAmount == null || desiredAmount == 0)
                return new ErrorValidationResult(_interestOptions.DesiredAmountNullError);
            return new SuccessValidationResult();
        }
        /// <summary>
        /// Istenen miktar sıfırdan küçük ise hata döndürür
        /// </summary>
        /// <param name="desiredAmount">İstene Miktar</param>
        /// <returns></returns>
        private IValidationResult CheckNegativeDesiredAmount(int desiredAmount)
        {
            if (desiredAmount < 0)
                return new ErrorValidationResult(_interestOptions.DesiredAmountNegativeError);
            return new SuccessValidationResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maturityAmount"></param>
        /// <returns></returns>
        private IValidationResult CheckMinDesiredAmount(int desiredAmount)
        {
            string errorMessage = String.Format(_interestOptions.DesiredAmountMinValueError, _interestOptions.DesiredAmountMinValue);
            if (desiredAmount < _interestOptions.DesiredAmountMinValue)
                return new ErrorValidationResult(errorMessage);
            return new SuccessValidationResult();
        }
        /// <summary>
        /// Vade tutarı null veya 0 ise hata döndürür
        /// </summary>
        /// <param name="maturityAmount">Vade Tutarı</param>
        /// <returns></returns>
        private IValidationResult CheckNullMaturityAmount(int maturityAmount)
        {
            if (maturityAmount == null || maturityAmount == 0)
                return new ErrorValidationResult(_interestOptions.MaturityAmountNullError);
            return new SuccessValidationResult();
        }
        /// <summary>
        /// Vade tutarı sıfırdan küçük ise hata döndürür
        /// </summary>
        /// <param name="maturityAmount">Vade Tutarı</param>
        /// <returns></returns>
        private IValidationResult CheckNegativeMaturityAmount(int maturityAmount)
        {
            if (maturityAmount < 0)
                return new ErrorValidationResult(_interestOptions.MaturityAmountNegativeError);
            return new SuccessValidationResult();
        }

    }
}
