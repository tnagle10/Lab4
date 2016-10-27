using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        private static bool keepGoing()
        {
            /* Name: keepGoing
            * Description:  This method implements a loop to determine if users wants to continue
            * Input:  None
            * Output: Returns 0 if user doesn't want to continue.  Otherwise returns 1.
            *         Outputs values to Console
            */


            // If user enters "q", execute exit procedure
            Console.WriteLine("\nContinue? (y/n):");
            string input = Console.ReadLine();

            if (input == "n")
            {
                Console.WriteLine("You entered n\n");
                Console.WriteLine("Are you sure you want to exit? (Type y to confirm)");
                input = Console.ReadLine();

                if (input == "y")
                {
                    return false;
                }

            }

            return true;
        }

        private static int getIntInRange(int start, int end)
        {
            /* Name: getIntInRange
            * Description:  This method takes a min and maximum value, and uses these values to prompt the
            *               user to enter a value in between these two values.  It does error checking 
            *               for valid numbers and makes sure the number is in the range.
            * Input:  Two long numbers are input.  The first is the min value (starting) and the other is the max value (ending).
            * Output: Returns 0 if user doesn't want to continue.  Otherwise returns 1.
            *         Outputs values to Console
            */

            // Set the boolean that the input is false to run while loop
            Boolean valid = false;
            // Initialize the input variable.
            int input = 0;

            // Ask the user for an integer.  Loop until they enter a valid integer, and an 
            // integer that is in the range between the starting and ending values.
            while (valid == false)
            {
                Console.WriteLine("Please enter an integer from " + start + " to " + end + ": ");
                // Valid integer continue
                if ((int.TryParse(Console.ReadLine(), out input)))
                {
                    // Valid number in the range, then mark valid flag
                    if ((input >= start) && (input <= end))
                    {
                        valid = true;
                    }
                }
            }
            return input;
        }

        static long calcFactUsingForLoop(int input)
        {
            /* Name: calcFactUsingForLoop
            * Description:  This method calculates a factorial number using a for loop.
            * Input:  The number that factorial should be calculated against.
            * Output: Returns the factorial as a long number.
            */
            long fact = 1;
            for (int i = 1; i <= input; i++)
            { fact = fact * i; }
            return fact;
        }

        static long calcFactUsingRecursion(int input)
        {
           /* Name: calcFactUsingRecursion
           * Description:  This method calculates a factorial number using recursion.
           * Input:  The number that factorial should be calculated against.
           * Output: Returns the factorial as a long number.
           */
            long fact = input;
            if (input == 1)
                return 1;
            return fact * calcFactUsingRecursion(input - 1);
        }

        static int calcFactMax()
        {
           /* Name: calcFactMax
           * Description:  This method calculates the maximum value that a factorial can be 
           *               calculated against before the factorial becomes too large to be calculated accurately.
           * Input:  None
           * Output: Returns an integer value that can be used to calculate factorial values
           */
            int i = 1;
            long fact = 1;
            bool positive = true;

            while (positive)
            {
                fact = fact * i;
                if (fact < 0)
                { positive = false; }
                else
                { i++; }
            }
            return i - 1;

        }

        static void Main(string[] args)
        {
            // Generate the start and end values for prompting user.
            int start = 1;
            int end = calcFactMax();
            
            // Loop until user decides to quit
            do
            {
                // Get a factorial value from user
                int max = getIntInRange(start, end);
                // Calculate factorial using for loop
                long factLoop = calcFactUsingForLoop(max);
                Console.WriteLine("The factorial of " + max + " using a for loop is equal to: " + factLoop);
                // Calculate factorial using recursion
                long factRecursion = calcFactUsingRecursion(max);
                Console.WriteLine("The factorial of " + max + " using recursion is equal to: " + factRecursion);

            } while (keepGoing());
        }
    }
}
