using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCQAExam.Pages
{
    public class RandomNameGenerator
    {
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string Email { get; set; }

        private static Random random = new Random();
        static void TestRandomNameGenerator()
        {
            Generate();

            System.Console.WriteLine("{0}", Name);
            System.Console.WriteLine("{0}", Surname);
            System.Console.WriteLine("{0}", Email);
        }

        public static void Generate()
        {
            random = new Random((int)DateTime.Now.Ticks);
            int NameLength = RandomNumber(2, 4);
            Name = RandomString(NameLength);
            int SurnameLength = RandomNumber(4, 6);
            Surname = RandomString(SurnameLength);

            StringBuilder builder = new StringBuilder();
            builder.Append(Name);
            builder.Append(Surname);
            builder.Append("@");
            builder.Append(RandomString(8, true));
            builder.Append(".");
            builder.Append(RandomString(3, true));
            Email = builder.ToString();
        }

        // Generate a random number between two numbers  
        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        // Generate a random string with a given size  
        public static string RandomString(int size, bool lowerCase = false)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                string ch1 = ch.ToString();
                if (i == 0)
                    ch1 = ch1.ToUpper();
                else
                    ch1 = ch1.ToLower();
                builder.Append(ch1);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
