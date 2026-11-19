using System.Text.RegularExpressions;

namespace StadiumMS.Helpers
{
    public static class Validator
    {
        private static readonly Regex EmailPattern = new Regex(@"^[A-Za-z0-9+_.-]+@(.+)$");

        public static bool IsValidEmail(string email)
        {
            return EmailPattern.IsMatch(email);
        }
    }
}
