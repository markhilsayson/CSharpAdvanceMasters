using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public static class StaticMessage
    {
        public static string Guide = "Options:\n" +
            "1.Rent a Video: To rent a video, type '1' and then enter the ID of the video you wish to rent.\n" +
            "2.Display Video List: To view all available videos, type '2'.This will display the details of all the videos.\n\n" +
            "Note: If you would like to continue after making your selection, type 'Y'.To exit, type 'N'.\n";

        public static string Options = "1. Rent a Video\n2. Display Video List\n3. Add a Video\n4. Delete a Video\n5. Get Specific Video by Year";

        public static string Welcome ="Welcome to Video Rent! We're excited to help you find your next movie adventure. With a wide selection of the latest releases and all-time favorites, you're sure to find something you love. So sit back, relax, and let us help you choose your next big screen experience. Happy renting!\n";

        public static string Menu = "****************************** MENU ******************************";

        public static string Selection = "Selection: ";

        public static string InvalidSelection = "Invalid Selection.\n";

        public static string InvalidID = "Invalid ID.\n";

        public static string Continue = "Do you want to continue? Y/y or N: ";

        public static string InvalidKeyword = "Invalid keyword. \n";

        public static string Closing = "Thank You!";

        public static string Rent = "Please input ID:";
    }
}
