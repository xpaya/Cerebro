using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CerebroInfo
{
    public static class Validate
    {
        public static bool ValidateUser(string username)
        {
            bool result = false;

            result = ValidUsers().Any(x => x.ToLower().Trim() == username.Trim().ToLower());

            return result;
        }


        private static List<string> ValidUsers()
        {
            List<string> result = new List<string>()
            {
                "Professor x",
                "xavier",
                "Charles Xavier",
                "Profesor x",
                "Cyclops",
                "cyclope",
                "Iceman",
                "hombre de hielo",
                "angel",
                "archangel",
                "bestia",
                "beast",
                "phoenix",
                "fenix",
                "wolverine",
                "lobezno",
                "storm",
                "tormenta",
                "banshee",
                "sunfire",
                "Colossus",
                "coloso",
                "thunderbird",
                "logan",
                "nightcrawler",
                "vulcan",
                "Darwin",
                "Sway",
                "petra",
                "Rogue",
                "picara",
                "Ariel",
                "Sprite",
                "ShadowCat",
                "Fénix",
                "mimic",
                "havok",
                "gambit",
                "gambito"

            };

            return result;

        }
    }

}
