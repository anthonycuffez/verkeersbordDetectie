using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace verkeersbordDetectie
{
    public static class TraficSignboards
    {
        private static string[] verkeersbordCodes = new string[149] { "B1", "B3", "B5", "B7", "B9", "B11", "B15A", "B15Ar", "B15Al", "B19", "B21", "B17", "B23", "B22", "M9", "M10", "M1", "M8", "A1a", "A1b", "A1c", "A1d", "A3", "A5", "A7a", "A7b", "A7c", "A9", "A11", "A13", "A14", "A15", "A17", "A19", "A21", "A23", "A25", "A27", "A29", "A31", "A41", "A43", "A45", "A47", "A49", "A51", "A39", "A37", "C1", "C3", "C5", "C7", "C9", "C11", "C19", "C22", "C21", "C23", "C13", "C25", "C27", "C29", "C31a", "C31b", "C33", "C24b", "C24a", "C24c", "C35", "C37", "C39", "C41", "C43-50", "200m", "M2", "M3", "D1a", "D1a3r", "D1e", "D1er", "D1alo", "D1aro", "D3b", "D5", "D7", "D11", "D9", "D10", "M6", "M7", "E1", "E3", "E5", "E7", "E9a", "E9b", "E9c", "E9d", "E9i", "E9e", "E9f", "E9g", "E9a-schijf", "3.5T", "F1b_V", "F1b_H", "F1a_V", "F1a_H", "F3b_V", "F3b_H", "F3a_V", "F3a_H", "F4a", "F4b", "F5", "F7", "F9", "F11", "F12a", "F12b", "F17", "F18", "F17-fiets", "F13-4", "F23b", "F23c", "F23a", "F23d", "F19", "F21", "F49", "F50", "F45", "F45b", "F79", "F81", "F83", "F85", "F89", "F91", "F87", "F111", "F113", "F97", "F97r", "F99a", "F101a", "F107", "F109" };
        public static List<string> getImageUrls()
        {
            List<string> imageUrls = new List<string>();

            int l = verkeersbordCodes.Length;
            for (int i = 0; i < l; i++)
            {
                imageUrls.Add("http://www.gratisrijbewijsonline.be/uploads/verkeersborden/" + verkeersbordCodes[i] + ".png");
            }
            
            return imageUrls;
        }

        public static List<string> getFilenames()
        {
            List<string> filenames = new List<string>();

            int l = verkeersbordCodes.Length;
            for (int i = 0; i < l; i++)
            {
                filenames.Add(verkeersbordCodes[i] + ".png");
            }
            
            return filenames;
        }
    }
}
