using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Assignment
{
    class Program
    {
        // todo
        // X display the result nicely
        // loop, ask user again, do want to run again?
        // move code out of Main
        static void Main(string[] args)
        {
            Loop();
        }

        static void Loop()
        {
            Compute();

            bool keepgoing = true;

            while(keepgoing)
            {
                bool hasagain = false;

                while (!hasagain)
                {
                    Console.Write("Again? [Y/N] ");
                    string line = Console.ReadLine();
                    if (line.ToLower() == "n")
                    {
                        keepgoing = false;
                        hasagain = true;
                    }
                    else if (line.ToLower() == "y")
                    {
                        Compute();
                        hasagain = true;
                    }

                    if(!hasagain)
                    {
                        Console.WriteLine("Y or N dummy");
                    }
                }
            }
        }

        static void Compute()
        {
            Selection s = Welcome();

            double result = ComputeProduct(s);
            Console.WriteLine("The " + Display(s) + " is: " + result + " " + Units(s));
        }

        enum Selection
        {
            Voltage, Current, Resistance
        }

        static string Units(Selection s)
        {
            switch (s)
            {
                case Selection.Voltage: return "volts";
                case Selection.Current: return "amperes";
                case Selection.Resistance: return "ohms";

                default: throw new Exception("Invalid Selection value: " + s);
            }
        }

        static double ComputeProduct(Selection s)
        {
            Tuple<Selection, Selection> others = OtherSelections(s);
            double other1 = CalculateSelection(others.Item1);
            double other2 = CalculateSelection(others.Item2);
            if (s == Selection.Voltage)
            {
                return other1 * other2;
            }
            else if (others.Item1 == Selection.Voltage)
            {
                return other1 / other2;
            } else
            {
                return other2 / other1;
            }
        }
        
        static double Minimum(Selection s)
        {
            switch(s)
            {
                case Selection.Voltage: return 0.0;
                case Selection.Current: return 0.01;
                case Selection.Resistance: return 10;
 
                default: throw new Exception("Invalid Selection value: " + s);
            }
        }

        static string Display(Selection s)
        {
            switch (s)
            {
                case Selection.Voltage: return "voltage";
                case Selection.Current: return "current";
                case Selection.Resistance: return "resistance";

                default: throw new Exception("Invalid Selection value: " + s);
            }
        }

        static Tuple<Selection, Selection> OtherSelections(Selection s)
        {
            switch (s)
            {
                case Selection.Voltage: return new Tuple<Selection, Selection>(Selection.Current, Selection.Resistance);
                case Selection.Current: return new Tuple<Selection, Selection>(Selection.Voltage, Selection.Resistance);
                case Selection.Resistance: return new Tuple<Selection, Selection>(Selection.Voltage, Selection.Current);

                default: throw new Exception("Invalid Selection value: " + s);
            }
        }

        static Selection Welcome()
        {
            int valuei = default(int);
            bool hasValue = false;

            Console.WriteLine("Welcome to Ohms Law Calculator");
            Console.WriteLine("[1] Calculate Voltage");
            Console.WriteLine("[2] Calculate Current");
            Console.WriteLine("[3] Calculate Resistance");
            Console.WriteLine("[4] Exit");
            Selection s = default(Selection);

            while (!hasValue)
            {
                Console.Write("Please Enter a Number: ");
                string values = Console.ReadLine();
                bool x = Int32.TryParse(values, out valuei);
                
                if(x)
                {
                    if(valuei == 1)
                    {
                        s = Selection.Voltage;
                        hasValue = true;
                    } else if(valuei == 2)
                    {
                        s = Selection.Current;
                        hasValue = true;
                    } else if(valuei == 3)
                    {
                        s = Selection.Resistance;
                        hasValue = true;
                    } else if(valuei == 4)
                    {
                        Environment.Exit(0);
                    }
                }
              
                if(!hasValue)
                {
                    Console.WriteLine("Please Enter a Number [1-4]");
                }
                
            }

            return s;
        }

        static double CalculateSelection(Selection s)
        {
            double r = default(double);
            bool hasValue = false;

            while (!hasValue)
            {
                Console.Write("Please enter " + Display(s) + ": ");
                string line = Console.ReadLine();
                bool x = Double.TryParse(line, out r);

                if(x)
                {
                    if(r >= Minimum(s))
                    {
                        hasValue = true;
                    } else
                    {
                        Console.WriteLine(r + " is below minimum " + Minimum(s) + " for " + Display(s));
                    }
                } else
                {
                    Console.WriteLine("Invalid value for " + Display(s));
                }
            }

            return r;
        }

        /*
        static void CalculateVoltage()     
        {
            Console.Write("Please enter Current: ");
            int currenti = 0;
            while (currenti <= 0)
            {
                string current = Console.ReadLine();
                bool x = Int32.TryParse(current, out currenti);
                if (!x)
                {
                    Console.Write("Please enter a valid current: ");
                }
            }

            int resistancei = 0;
            while (resistancei <= 0)
            {
                Console.Write("Please enter Resistance: ");
                string resistance = Console.ReadLine();
                bool x = Int32.TryParse(resistance, out resistancei);
                if (!x)
                {
                    Console.WriteLine("Please enter a valid Resistance: ");
                }
            }
            Console.WriteLine("The Voltage is " + (currenti * resistancei));

        }
        */
    }


}
