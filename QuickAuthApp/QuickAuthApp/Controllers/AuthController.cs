using Domain.Requests.Auth.Queries;
using Microsoft.AspNetCore.Mvc;
using QuickAuthApp.Core.Domain.Requests.Auth.Queries;

namespace QuickAuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        /// <summary>
        /// This api returns the otp for given username and store it for 30 sec.
        /// </summary>
        /// <param name="userName">Input to for which this method creates otp</param>
        /// <returns></returns>
        [HttpGet("generate-otp")]
        public async Task<IActionResult> GenrateOtp(string userName)
        {
            var data = await Mediator.Send(new GenerateOtpQuery(userName)).ConfigureAwait(false);
            return Ok(data);
        }

        /// <summary>
        /// This api will validate the otp against the username
        /// </summary>
        /// <param name="request">Otp and Username</param>
        /// <returns></returns>
        [HttpPost("validate-otp")]
        public async Task<IActionResult> ValidateOtp([FromBody] ValidateOtpQuery request)
        {
            var isValid = await Mediator.Send(request).ConfigureAwait(false);
            return Ok(isValid);
        }
    }
}
