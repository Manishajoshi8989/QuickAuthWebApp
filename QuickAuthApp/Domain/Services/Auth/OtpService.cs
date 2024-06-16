namespace Domain.Services.Auth
{
    public class OtpService : IOtpService
    {
        #region Data Members
        private readonly Dictionary<string, (string Otp, DateTime Expiry)> _otpStore = new();
        #endregion

        #region Public Methods
        public string GenerateOtp(string username)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            _otpStore[username] = (otp, DateTime.Now.AddSeconds(30));
            return otp;
        }

        public bool ValidateOtp(string username, string otp)
        {
            if (_otpStore.TryGetValue(username, out var value) && value.Otp == otp && value.Expiry > DateTime.Now)
            {
                return true;
            }
            else
            {
                _otpStore.Remove(username);
                return false;
            }
        }
        #endregion
    }
}
