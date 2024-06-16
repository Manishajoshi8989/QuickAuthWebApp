using MediatR;

namespace QuickAuthApp.Core.Domain.Requests.Auth.Queries
{
    public class GenerateOtpQuery : IRequest<GenerateOtpDTO>
    {
        public string UserName { get; set; } 

        public GenerateOtpQuery(string userName)
        {
            UserName = userName;
        }
    }

    public class GenerateOtpDTO
    {
        public string? Otp { get; set; }

    }
}