using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
 /// <summary>
    /// Applicationenn läser in ett godtyckligt antal löner och sedan beräknar:
    /// a) medianlön, b) medellön och c) lönespridning. 
    /// Programmet presenterar, efter de beräknade värdena, lönerna i den ordning de matats in i med tre löner per rad.  
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main metoden anropar ReadInt() för att läsa in antalet löner som användaren vill mata in. 
        /// Sedan anropas metoden ProcessSalaries för att läsa in lönerna.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "Godtycklig lönerevision!";
            do
            {
                int size = ReadInt("Ange antal löner att mata in : ");

                //Om antalet löner att bearbeta är färre än två  - ett felmeddelande presenteras 
                //och användaren får att välja mellan att få en ny chans att mata in löner, 
                //eller att avsluta applicationen.
                if (size < 2)
                {

                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nDu måste ange minst två löner för att kunna göra en beräkning!\n");
                    Console.ResetColor();

                }
                else
                {
                    ProcessSalaries(size);
                }

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck tangent för ny beräkning - Esc avslutar.\n");
                Console.ResetColor();

                //Escape - continue sats---> " true " är onödig?

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    return;
                }

                size = 0;

            }
            while (true);

        }

        /// <summary>
        ///  Metoden läser in lönerna till en lokal array av typen int[]. 
        ///  Efter att lönerna har lästs in, beräknas median, medellön och lönespridning.
        ///  De beräknade resultaten  presenteras:
        ///  a) formaterade som valuta, 
        ///  b)varefter de inmatade lönerna  listas, med tre löner på varje rad, i den ordning de matades in.
        /// </summary>
        /// <param name="size">(int size)</param>
        static void ProcessSalaries(int size)
        {
            //Deklarear variabeln.
            int[] salaries = new int[size];

            Console.WriteLine("");

            for (int i = 0; i < salaries.Length; ++i)
            {
                salaries[i] = ReadInt(String.Format("Ange lön nummer {0} : ", i + 1));
            }

            //Gör en kopia av arrayn innan den nödvändiga sorteringen.
            int[] copy = new int[size];
            Array.Copy(salaries, copy, size);

            //Sorterar arrayn för de rätta beräkningar.
            Array.Sort(salaries);

            //Beräknar "Medianlön" - udda / jämna tal.
            int median;
            if (salaries.Length % 2 == 0)//in case it's even
            {
                int n = salaries.Length / 2;
                median = (salaries[n - 1] + salaries[n]) / 2;
            }
            else
            {
                median = salaries[(salaries.Length) / 2];
            }

            //Beräknar  löneskillnaden mellan den störta och minsta.
            //Presenterar resultatet.
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("Medianlön:      {0, 10:c0}", median);
            Console.WriteLine("Medellön:       {0, 10:c0}", salaries.Average());
            Console.WriteLine("Lönespridning:  {0, 10:c0}", salaries.Max() - salaries.Min());
            Console.WriteLine("------------------------------");

            //De inmatade lönerna  listas, med tre löner på varje rad,med hjälp av modulusoperatorn (%).
            //  "/n" bryter rad.
            for (int i = 1; i <= size; i++)
            {
                Console.Write("{0, 7}   ", copy[i - 1]);

                if (i % 3 == 0)
                {
                    Console.WriteLine("\n");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Metoden läser in antalet löner som användaren vill mata in.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private static int ReadInt(string prompt)
        {
            string input = null;

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    input = Console.ReadLine();
                    return int.Parse(input);
                }
                catch
                {
                    //Om det inmatade inte kan tolkas som ett korrekt värde (heltal),
                    //får användaren en ny chans att göra en ny inmatning efter att ett tydligt felmeddelande presenterats.

                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFel! {0} kan inte tolkas som ett heltal!\n", input);
                    Console.ResetColor();
                }
            }
        }
    }
}

