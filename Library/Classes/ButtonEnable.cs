using Library.Models;

namespace Library.Classes
{
    public static class ButtonEnable
    { 
        public static bool TeamsEdit(int? id, Users user)
        {
            if (user.Type == "Admin")
            {
                return true;
            }
            if (user.Type == "Team" && id == user.Id)
            {
                return true;
            }
            return false;
        }

        public static bool GpEdit(int? id, Users user)
        {
            if (user.Type == "Admin")
            {
                return true;
            }
            if (user.Type == "GP" && id == user.Id)
            {
                return true;
            }
            return false;
        }
    }
}
