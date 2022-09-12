

namespace EmailCreatorConsoleApp
{
    public class Program
    {
        static void Main(String[] args)
        {
            MainMenu mainMenu = new MainMenu();

            mainMenu.InformationPart();
        }
    }

    public class MainMenu 
    {
        //## Method of the starter menu
        public void InformationPart()
        {
            Console.WriteLine("--> ( EMAIL CREATOR ) <--\n");
            Console.WriteLine("This console application will create a new email address by entering some details.\n");
            Thread.Sleep(1500);
            Console.WriteLine("Want to begin? [Y / N]\n");
            string answer = Console.ReadLine();
            answer = answer.ToUpper();

            if (answer == "Y")
            {
                EnterDetails();
            }
            else
            {
                ClearingScreen();
                Thread.Sleep(900);
                Console.WriteLine("Sad to see you go. Until next time.\n");
                Thread.Sleep(1000);
                Console.WriteLine("The console application will now end. . .");
                Thread.Sleep(1800);
                System.Environment.Exit(0);

            }
        }

        //## Method the collects the information of the user
        public void EnterDetails()
        {
            string firstname, lastname, emailNumbAns, emailHandle, number, mergedNames;

            ClearingScreen();

            Console.WriteLine("> What is your first name?");
            firstname = Console.ReadLine().ToLower();
            Console.WriteLine("\n> What is your last name?");
            lastname = Console.ReadLine().ToLower();


            Console.WriteLine("\n> Would you like to include numbers in your new email address? [Y / N]");
            emailNumbAns = Console.ReadLine();
            emailNumbAns = emailNumbAns.ToUpper();

            if (emailNumbAns == "Y")
            {
                mergedNames = Merger(firstname, lastname);

                Console.WriteLine("\n> Please enter the number you wish to add:");
                number = Console.ReadLine();

                emailHandle = Merger(mergedNames, number);
            }
            else
            {
                emailHandle = Merger(firstname, lastname);
            }

            EmailGenerator(emailHandle);
        }

        //## Method that concatenates two strings
        static string Merger(string x, string y)
        {
            string input = x + y;
            return input;
        }

        // ## Method that adds the @ to the name
        static void EmailGenerator(string emailname)
        {
            string fullemail;
            ClearingScreen();

            Console.WriteLine("Please pick an email provider:");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[1] @gmail.com");
            Console.WriteLine("[2] @yahoo.com");
            Console.WriteLine("[3] @outlook.com");
            Console.WriteLine("[4] I will provide my own\n");
            Console.ResetColor();

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    fullemail = emailname + "@gmail.com";
                    FinalScreen(fullemail);
                    break;
                case "2":
                    fullemail = emailname + "@yahoo.com";
                    FinalScreen(fullemail);
                    break;
                case "3":
                    fullemail = emailname + "@outlook.com";
                    FinalScreen(fullemail);
                    break;
                case "4":
                    Console.WriteLine("\nEnter the email provider, including the @:");
                    string customEmailProvider = Console.ReadLine();
                    fullemail = emailname + customEmailProvider;
                    FinalScreen(fullemail);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease try again. . .");
                    Console.ResetColor();
                    EmailGenerator(emailname);
                    break;
            }
        }

        //## Method that displays the new email address
        static void FinalScreen(string email)
        {
            ClearingScreen();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Generating new email address. . . ");
            Thread.Sleep(1350);
            Console.WriteLine("\nOne moment. . .");
            Console.ResetColor();
            Thread.Sleep(1050);
            Console.WriteLine($"\nEmail address: {email}");
            Console.WriteLine("\n\nThank you for using the Email Creator App. The console will now end. . .\n\n");
            Console.ReadKey();           
        }

        //## Method that clears the console and displays main title 
        static void ClearingScreen()
        {
            Console.Clear();
            Console.WriteLine("--> ( EMAIL CREATOR ) <--\n");
        }
    }
}