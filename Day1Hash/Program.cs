using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day1Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 - Take user input
            // Step 2 - Encrypt user input

            string myInput = Console.ReadLine();

            byte[] byteData = Encoding.UTF8.GetBytes(myInput);
            Stream inputStream = new MemoryStream(byteData);

            using (SHA256 shaM = new SHA256Managed())
            {
                var result = shaM.ComputeHash(inputStream);
                string output = BitConverter.ToString(result);
                Console.WriteLine(output.Replace("-", "").Substring(0, 5));
            }
        }
    }
}
