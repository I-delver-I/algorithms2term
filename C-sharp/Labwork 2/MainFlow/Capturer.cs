using System;

namespace Labwork_2.MainFlow
{
    public class Capturer
    {
        public static int CaptureUserNumber(int usersCount)
        {
            int userNumber = 1;
            bool exceptionIsCaught;

            do
            {
                exceptionIsCaught = false;
                
                Console.Write($"Enter the number of user whom hit-parade you want to" +
                    $" compare with others (from 1 to {usersCount}): ");
                
                try
                {
                    userNumber = Convert.ToInt32(Console.ReadLine());
                    
                    if (userNumber < 1 || userNumber > usersCount)
                    {
                        throw new ArgumentException("The count of users isn't valid!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The entered value isn't a number!");
                    exceptionIsCaught = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionIsCaught = true;
                }
            } while (exceptionIsCaught);
            
            return userNumber;
        }
    }
}