using System.Globalization;

namespace consoleApp
{
	public class MyClass
	{
        static int count = 0;
        static int capacity = 10;
        static string[] history = new string[capacity];

        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");

            Menu();
        }


        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Enter a command:");
                Console.WriteLine("1. BMI");
                Console.WriteLine("2. Show history:");
                Console.WriteLine("3. Clear history:");
                Console.WriteLine("4. Exit:");

                if (!int.TryParse(Console.ReadLine(), out var command))
                {
                    Console.WriteLine("Not correct");
                    continue;
                }

                if (command == 1)
                {
                    SecondMethod();
                }
                else if (command == 2)
                {
                    for (var i = 0; i < count; i++)
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine(history[i]);
                    }

                    continue;
                }
                else if (command == 3)
                {
                    Console.WriteLine("Cleared");
                    Console.WriteLine("Deleted " + count + "zapisei");
                    count = 0;
                    continue;
                }
                else if (command == 4)
                {
                    break;
                }
            }
        }

        public static void SecondMethod()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Hallo " + name);

            int age = ReadInt("Enter your age: ");
            if (age < 18 || age > 65)
            {
                Console.WriteLine("It's not for you");
                return;
            }

            double weight = ReadDouble("Enter your weight in KG:");
            if (weight < 35 || weight > 135)
            {
                Console.WriteLine("Your weight is not available for our product");
                return;
            }

            double height = ReadDouble("Enter your height in meters:");
            if (height < 0 || height > 2.8)
            {
                Console.WriteLine("Not available");
                return;
            }

            char gender = ReadGender("Enter your gender (m/f/another): ");

            double bmi = CalculateBMI(weight, height);
            Console.WriteLine("Your BMI is = " + bmi);

            EvaluateBMI(gender, bmi);

            if (count == capacity)
            {
                capacity *= 2;
                Array.Resize(ref history, capacity);
            }

            string report = "Name: " + name + "\n" +
                            "Age: " + age + "\n" +
                            "Weight: " + weight + "\n" +
                            "Height: " + height + "\n" +
                            "Gender: " + gender + "\n" +
                            "BMI: " + bmi;

            history[count] = report;
            count++;
        }

        public static double ReadDouble(string message)
        {
            double value;
            Console.WriteLine(message);
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                Console.WriteLine("Not correct, try again:");
            }

            return value;
        }

        public static int ReadInt(string message)
        {
            int value;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Not correct, try again:");
            }

            return value;
        }

        public static char ReadGender(string message)
        {
            char gender;
            Console.WriteLine(message);
            while (!char.TryParse(Console.ReadLine(), out gender) || (gender != 'm' && gender != 'f' && gender != 'a'))
            {
                Console.WriteLine("Not correct, try again:");
            }

            return gender;
        }

        public static double CalculateBMI(double weight, double height)
        {
            return weight / (height * height);
        }

        public static void EvaluateBMI(char gender, double bmi)
        {
            if (gender == 'm')
            {
                if (bmi < 18.5)
                {
                    Console.WriteLine("You're underweight");
                }
                else if (bmi >= 18.5 && bmi < 23.8)
                {
                    Console.WriteLine("Its ok");
                }
                else if (bmi >= 23.8 && bmi < 27.3)
                {
                    Console.WriteLine("You're overweight");
                }
                else if (bmi >= 27.3 && bmi < 30.0)
                {
                    Console.WriteLine("You're obese to the 1st degree");
                }
                else if (bmi >= 30.0 && bmi < 35.0)
                {
                    Console.WriteLine("You're obese to the 2nd degree");
                }
                else if (bmi >= 35.0)
                {
                    Console.WriteLine("You're obese to the 3rd degree");
                }
            }
            else if (gender == 'f')
            {
                if (bmi < 20.1)
                {
                    Console.WriteLine("You're underweight");
                }
                else if (bmi >= 20.1 && bmi < 24.9)
                {
                    Console.WriteLine("Its ok");
                }
                else if (bmi >= 24.9 && bmi < 29)
                {
                    Console.WriteLine("You're overweight");
                }
                else if (bmi >= 29 && bmi < 34.9)
                {
                    Console.WriteLine("You're obese to the 1st degree");
                }
                else if (bmi >= 34.9 && bmi < 40)
                {
                    Console.WriteLine("You're obese to the 2nd degree");
                }
                else if (bmi >= 40)
                {
                    Console.WriteLine("You're obese to the 3rd degree");
                }
            }
        }
    }
}

