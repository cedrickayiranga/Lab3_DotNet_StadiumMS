using StadiumMS.Models;

namespace StadiumMS.Helpers
{
    public static class Session
    {
        public static User CurrentUser { get; set; }

        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}
