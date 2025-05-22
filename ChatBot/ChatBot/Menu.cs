using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ChatBot
{
    internal class MenuDisplay
    {
        public static void LoadMenu(string personName)
        {
            Library library = new Library();
            library.LoadData();
            

            //Implement your logic to display menu options using loops
            // use this logic to search for user topic, declare variables to store userInput based on the search
            //  var data = library.data.FirstOrDefault(x => x.Subject.Contains(userInput.ToLower()));


        }

    }
}