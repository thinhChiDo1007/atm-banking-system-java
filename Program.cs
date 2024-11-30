using System;
using System.Diagnostics;
using System.Threading.Channels;

//ID:A00127714
//Name:JJG
namespace Task_xy
{
    internal class Program
    {
        static Bank bank = new Bank();
        

        static void Main(string[] args)
        {
            HomeView();
        }

        static void HomeView()
        {
            Console.Clear();
            Console.WriteLine("Welcome to abc Bank");
            Console.WriteLine("1:Login");
            Console.WriteLine("2:Signup");
            Console.WriteLine("3:Quit");
            Console.Write("Select Qption:");

            int num = int.Parse(Console.ReadLine());

            if (num == 1)
            {
                LoginView();
            }
            else if (num == 2)
            {
                SignupView();
            }
            else if (num == 3)
            {
                return;
            }

        }

        static void LoginView()
        {
            Console.Write("Enter email:");
            string email = Console.ReadLine();
            Console.Write("Enter password:");
            string password = Console.ReadLine();

            var user = bank.Login(email, password);
            if (user != null)
            {
                Console.WriteLine("Login Success");
                UserMenu(user);
            }
            else
            {
                Console.WriteLine("Invalid email or password");
                LoginFailView();
            }

            

        }

        static void LoginFailView()
        {
            
            Console.WriteLine("1: Try again");
            Console.WriteLine("2: Main menu");
            Console.WriteLine("3: Quit");

            int num = int.Parse(Console.ReadLine());

            if (num == 1)
            {
                LoginView();
            }
            else if (num == 2)
            {
                HomeView();
            }
            else if (num == 3)
            {
                return;
            }
        }



        static void SignupView()
        {
            Console.Write("Enter email:");
            string email = Console.ReadLine();
            Console.Write("Enter password:");
            string password = Console.ReadLine();

            if (email == "" || password == "")
            {
                Console.WriteLine("Invalid email or password");
                SignupFailView();
            }
            else
            {
                bank.Signup(email, password);
                Console.WriteLine("Signup success");
                HomeView();
            }

        }

        static void SignupFailView()
        {
            Console.WriteLine("1: Try again");
            Console.WriteLine("2: Main menu");
            Console.WriteLine("3: Quit");
            Console.Write("Select Qption:");

            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                SignupView();
            }
            else if (num == 2)
            {
                HomeView();
            }
            else if (num == 3)
            {
                return;
            }
        }

        static void UserMenu(User user)
        {

            Console.WriteLine("Welcome ");
            Console.WriteLine("1:View Balance");
            Console.WriteLine("2:Deposite");
            Console.WriteLine("3:Withdraw");
            Console.WriteLine("4:Transfer");
            Console.WriteLine("5.Quit");
            Console.Write("Select Qption:");

            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                ViewBalanceView(user);
            }
            else if (num == 2)
            {
                DepositeView(user);
            }
            else if (num == 3)
            {
                WithdrawView(user);
            }
            else if (num == 4)
            {
                //TransferView();
            }
            else if (num == 5)
            {
                return;
            }
            
        }

        static void ViewBalanceView(User user)
        {
            Console.WriteLine("Your balance is: " + user.Balance);


            UserMenu(user);
        }

        static void DepositeView(User user)
        {
            Console.Write("Enter amount:");
            decimal amount = decimal.Parse(Console.ReadLine());
            
            bank.Deposit(amount, user);

            Console.WriteLine("Deposite success");

            UserMenu(user);
        }

        static void WithdrawView(User user)
        {
            
            Decimal amount;

            if (!bank.WithdrawAllowed())
            {
                Console.WriteLine("Security check, too many withdrawls try again later");
            } else
            {
                Console.WriteLine("Enter amount:");
                String input = Console.ReadLine();

                if (!decimal.TryParse(input, out amount))
                {
                    Console.WriteLine("Only numerical data to be entered for withdrawal");
                }
                else if (amount <= 0)
                {
                    Console.WriteLine("Only non negative amounts");
                }
                else
                {
                    if (bank.Withdraw(amount, user))
                    {
                        Console.WriteLine("Withdraw success");
                    }
                    else
                    {
                        Console.WriteLine("Not sufficient fund available");
                    }
                }
            }

            UserMenu(user);
        }



        //static void Main1(string[] args)
        //{
        //    MainMenu1();
        //    int num = int.Parse(Console.ReadLine());
        //    if (num == 1)
        //    {
        //        Return();
        //    }
        //    else if (num == 2)
        //    {
        //        Console.Write("Enter Username:");
        //        string Username = Console.ReadLine();
        //        Console.Write("Enter Email:");
        //        string Email= Console.ReadLine();
        //        Console.Write("Enter Age:");
        //        string Age = Console.ReadLine();
        //        Console.Write("Enter Phone:");
        //        string Phone = Console.ReadLine();
        //        Console.Write("Enter Password:");
        //        string Password = Console.ReadLine();
        //        //Bank bank1 = new Bank();
        //        if(Username!=""&& Email!= "" && Age!= "" && Phone != "" && Password != "")
        //        {
        //            bank.signup(Username, Email, Age, Phone, Password);
        //            Console.WriteLine("signup successful!");
        //            MainMenu4();

        //            Return();
        //        }
        //        else
        //        {
        //            Console.WriteLine("the option cannot be empty!");
        //        } 
        //    }
        //    else if (num == 3)
        //    {
        //        return;
        //    }
        //}

        //public static void MainMenu1()
        //{
        //    Console.WriteLine("Welcome to abc Bank");
        //    Console.WriteLine("1:Login");
        //    Console.WriteLine("2:Signup");
        //    Console.WriteLine("3:Quit");
        //    Console.Write("Select Qption:" ); 
        //}
        //public static void MainMenu2()
        //{
        //    Console.WriteLine("1:Try again");
        //    Console.WriteLine("2:Main menu");
        //    Console.WriteLine("3:Quit");
        //    Console.Write("Select Qption:");
        //}
        //public static void MainMenu3()
        //{
        //    Console.WriteLine("Welcome John");
        //    Console.WriteLine("1:View Balance");
        //    Console.WriteLine("2:Deposite");
        //    Console.WriteLine("3:Withdraw");
        //    Console.WriteLine("4:Transfer");
        //    Console.WriteLine("5.Quit");
        //}
        //public static void MainMenu4()
        //{
        //    Console.WriteLine("Welcome to abc Bank");
        //    Console.WriteLine("Login");
        //}

        //public static void Return()
        //{
        //    Console.Write("Enter username:");
        //    string Username = Console.ReadLine();
        //    Console.Write("Enter your password:");
        //    string Password = Console.ReadLine();
        //    // Bank bank = new Bank();
        //    for (int i = 0; i < 2; i++)
        //    {
        //        if (!bank.Login(Username, Password))
        //        {
        //            Console.WriteLine("Invalid email or password");
        //            MainMenu2();
        //            int num2 = int.Parse(Console.ReadLine());
        //            if (num2 == 1)
        //            {
        //                Console.Write("Enter username:");
        //                Username = Console.ReadLine();
        //                Console.Write("Enter your password:");
        //                Password = Console.ReadLine();
        //            }
        //            else if (num2 == 2)
        //            {
        //                MainMenu1();
        //            }
        //            else if (num2 == 3)
        //            {
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            MainMenu3();
        //            break;
        //        }
        //    }
        //}
    }
}
