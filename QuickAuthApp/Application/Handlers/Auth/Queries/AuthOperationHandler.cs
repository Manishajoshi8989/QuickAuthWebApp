using Domain.Requests.Auth.Queries;
using Domain.Services.Auth;
using MediatR;
using QuickAuthApp.Core.Domain.Requests.Auth.Queries;

namespace QuickAuthApp.Core.Application.Auth.Queries
{
    public class AuthOperationHandler : IRequestHandler<GenerateOtpQuery, GenerateOtpDTO>,
        IRequestHandler<ValidateOtpQuery, bool>
    {
        #region DataMember
        private readonly IOtpService _otpService;
        #endregion

        #region Ctor
        public AuthOperationHandler(IOtpService otpService)
        {
            _otpService = otpService;
        }
        #endregion

        #region Public Methods
        public async Task<GenerateOtpDTO> Handle(GenerateOtpQuery request, CancellationToken cancellationToken)
        {
            var generateOtp = new GenerateOtpDTO();
            generateOtp.Otp = _otpService.GenerateOtp(request.UserName);
            return generateOtp;

        }

        public async Task<bool> Handle(ValidateOtpQuery request, CancellationToken cancellationToken)
        {
            return _otpService.ValidateOtp(request.UserName, request.Otp);
        } 
        #endregion
    }
}
