namespace Domain.Services.Auth
{
    public interface IOtpService
    {
        /// <summary>
        /// This will generate OTP for given Username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns></returns>
        string GenerateOtp(string username);

        /// <summary>
        /// Validate OTP against given username
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="otp">otp</param>
        /// <returns></returns>
        bool ValidateOtp(string username, string otp);
    }
}
