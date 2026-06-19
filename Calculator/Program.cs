using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    class Program
    {
        // ================================
        // ✅ history در اینجا تعریف میشه
        // ================================
        static List<string> history = new List<string>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ================================
            // ✅ حلقه بی‌نهایت برای تکرار منو
            // ================================
            while (true)
            {
                Console.Clear();
                ShowMenu();

                Console.Write("\n\nYour Choice: ");
                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n👋 Goodbye! Thanks for using Calculator!");
                    Console.ResetColor();
                    break;
                }

                HandleChoice(choice);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        // ================================
        // ✅ نمایش منو
        // ================================
        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("║      Calculator Project          ║");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("┌──────────────────────────────────┐");
            Console.WriteLine("│                                  │");
            Console.WriteLine("│            Main Menu             │");
            Console.WriteLine("│                                  │");
            Console.WriteLine("├──────────────────────────────────┤");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("│   1.Addition (+)                 │");
            Console.WriteLine("│   2.Subtraction (-)              │");
            Console.WriteLine("│   3.Multiplication (*)           │");
            Console.WriteLine("│   4.Division (/)                 │");
            Console.WriteLine("│   5.Power (x^y)                  │");
            Console.WriteLine("│   6.Square Root (√x)             │");
            Console.WriteLine("│   7.Percentage (%)               │");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("│   8.History                      │");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("│   0.Exit                         │");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("└──────────────────────────────────┘");
            Console.ResetColor();
        }

        // ================================
        // ✅ مدیریت انتخاب کاربر
        // ================================
        static void HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Addition();
                    break;
                case "2":
                    Subtraction();
                    break;
                case "3":
                    Multiplication();
                    break;
                case "4":
                    Division();
                    break;
                case "5":
                    Power();
                    break;
                case "6":
                    SquareRoot();
                    break;
                case "7":
                    Percentage();
                    break;
                case "8":
                    ShowHistory();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Invalid choice! Please try again.");
                    Console.ResetColor();
                    break;
            }
        }

        // ================================
        // ✅ عملیات جمع
        // ================================
        static void Addition()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 Addition Operation");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            double num1 = GetValidNumber("Please enter the first number: ");
            double num2 = GetValidNumber("Please enter the second number: ");

            double result = num1 + num2;
            string resultText = $"{num1} + {num2} = {result}";

            ShowResult(resultText);
            history.Add(resultText);
        }

        // ================================
        // ✅ عملیات تفریق
        // ================================
        static void Subtraction()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 Subtraction Operation");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            double num1 = GetValidNumber("Please enter the first number: ");
            double num2 = GetValidNumber("Please enter the second number: ");

            double result = num1 - num2;
            string resultText = $"{num1} - {num2} = {result}";

            ShowResult(resultText);
            history.Add(resultText);
        }

        // ================================
        // ✅ عملیات ضرب
        // ================================
        static void Multiplication()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 Multiplication Operation");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            double num1 = GetValidNumber("Please enter the first number: ");
            double num2 = GetValidNumber("Please enter the second number: ");

            double result = num1 * num2;
            string resultText = $"{num1} * {num2} = {result}";

            ShowResult(resultText);
            history.Add(resultText);
        }

        // ================================
        // ✅ عملیات تقسیم (با مدیریت خطا)
        // ================================
        static void Division()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 Division Operation");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            double num1 = GetValidNumber("Please enter the numerator: ");
            double num2 = GetValidNumber("Please enter the denominator: ");

            // ✅ مدیریت تقسیم بر صفر
            if (num2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Error! Division by zero is not allowed!");
                Console.ResetColor();
                return;
            }

            double result = num1 / num2;
            string resultText = $"{num1} / {num2} = {result:F2}";

            ShowResult(resultText);
            history.Add(resultText);
        }

        // ================================
        // ✅ عملیات توان
        // ================================
        static void Power()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 Power Operation");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            double num1 = GetValidNumber("Please enter the base number: ");
            double power = GetValidNumber("Please enter the exponent: ");

            double result = Math.Pow(num1, power);
            string resultText = $"{num1} ^ {power} = {result:F4}";

            ShowResult(resultText);
            history.Add(resultText);
        }

        // ================================
        // ✅ عملیات ریشه (با مدیریت خطا)
        // ================================
        static void SquareRoot()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 Square Root Operation");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            double num = GetValidNumber("Please enter the number: ");

            // ✅ مدیریت ریشه اعداد منفی
            if (num < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Error! Cannot calculate square root of a negative number!");
                Console.ResetColor();
                return;
            }

            double result = Math.Sqrt(num);
            string resultText = $"√{num} = {result:F4}";

            ShowResult(resultText);
            history.Add(resultText);
        }

        // ================================
        // ✅ عملیات درصد
        // ================================
        static void Percentage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 Percentage Operation");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            double num = GetValidNumber("Please enter the number: ");
            double percentage = GetValidNumber("Please enter the percentage: ");

            double result = (num * percentage) / 100;
            string resultText = $"{percentage}% of {num} = {result:F2}";

            ShowResult(resultText);
            history.Add(resultText);
        }

        // ================================
        // ✅ دریافت عدد با اعتبارسنجی
        // ================================
        static double GetValidNumber(string prompt)
        {
            double number = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(prompt);
                Console.ResetColor();

                string input = Console.ReadLine();

                if (double.TryParse(input, out number))
                {
                    isValid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Invalid input! Please enter a valid number.");
                    Console.ResetColor();
                }
            }

            return number;
        }

        // ================================
        // ✅ نمایش نتیجه با جعبه
        // ================================
        static void ShowResult(string resultText)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ┌──────────────────────────────────┐");
            Console.WriteLine(" │                                  │");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" │  Result: {resultText,-20} │");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" │                                  │");
            Console.WriteLine(" └──────────────────────────────────┘");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ Operation completed successfully!");
            Console.ResetColor();
        }

        // ================================
        // ✅ نمایش تاریخچه
        // ================================
        static void ShowHistory()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📜 History");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            if (history.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("📭 No calculations in history yet!");
                Console.ResetColor();
                return;
            }

            for (int i = 0; i < history.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{i + 1}. {history[i]}");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\n📊 Total calculations: {history.Count}");
            Console.ResetColor();
        }
    }
}