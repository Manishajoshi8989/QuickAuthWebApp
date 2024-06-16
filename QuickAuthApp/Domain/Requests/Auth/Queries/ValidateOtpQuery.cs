using MediatR;

namespace Domain.Requests.Auth.Queries
{
    public class ValidateOtpQuery : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Otp { get; set; }

        public ValidateOtpQuery(string username, string otp)
        {
            UserName = username;
            Otp = otp;
        }
    }
}
