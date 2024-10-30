namespace conversion
{
    class Program
    {
        static void Main()
        {
            // Prompt user to input a number
            Console.WriteLine("Enter a number to convert to words (supports up to four digits):");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                // Check if the number exceeds the 4-digit limit
                if (number > 9999 || number < -9999)
                {
                    Console.WriteLine("Invalid input. Please enter a number with up to four digits.");
                }
                else
                {
                    // Convert number to words and display the result
                    string result = NumberToWords(number);
                    Console.WriteLine("The number in words is: " + result);
                }
            }
           
        }
        static string NumberToWords(int number)
        {
            // Handle special case for zero
            if (number == 0)
                return "Zero";

            // Handle negative numbers
            if (number < 0)
                return "Minus " + NumberToWords(Math.Abs(number));

            string words = "";

            // Handle thousands 
            if (number >= 1000)
            {
                int thousands = number / 1000;
                words += DigitToWord(thousands) + " Thousand ";
                number %= 1000;
            }

            // Handle hundreds place
            if (number >= 100 && number < 1000)
            {
                int hundreds = number / 100;
                words += DigitToWord(hundreds) + " Hundred ";
                number %= 100;
            }

            // Handle tens place for numbers 20 
            if (number >= 20 && number < 100)
            {
                int tens = number / 10;
                words += TensToWord(tens);
                number %= 10;

                // Add hyphen if there's a unit place
                if (number > 0)
                    words += "-" + DigitToWord(number);
            }
            else if (number > 0)
            {
                // Handle numbers from 1 to 19
                words += DigitToWord(number);
            }

            // Return the final result
            return words;
        }

        // Converts single digit numbers or numbers up to 19 to words
        static string DigitToWord(int number)
        {
            string[] units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                                  "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            return units[number];
        }

        // Converts tens place numbers to words
        static string TensToWord(int tens)
        {
            string[] tensNum = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            return tensNum[tens];
        }
    }
}
