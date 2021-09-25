using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATMSystem
{
    public class Atm
    {
        private bool _loginRequest { get; set; }
        public Atm()
        {
            _loginRequest = true;
            Console.WriteLine("Welcome to the Simple ATM System!\n======================================\n");
            while(_loginRequest)
            {
                LoginInput();
            }
        }
        private void LoginInput()
        {
            Console.Write("Enter Account Number: ");

            string input = Console.ReadLine();
            while (!int.TryParse(input, out _))
            {
                Console.WriteLine("Wrong Account Number Input Format.\n");
                Console.Write("Enter Account Number: ");
                input = Console.ReadLine();
            }
            int accNum = Convert.ToInt32(input);
            AuthenticateAccount(accNum);
        }

        private void AuthenticateAccount(int accNum)
        {
            using (var context = new ApplicationDbContext())
            {
                if (context.Accounts.Any(o => o.AccountNumber == accNum))
                {
                    var account = context.Accounts.Single(a => a.AccountNumber == accNum);

                    Console.Write("Enter PIN: ");
                    string pin = Console.ReadLine();

                    if (PasswordHasher.ValidateHash(account.PinHash, pin))
                    {
                        Menu(account);
                        context.SaveChanges();
                    }
                    else
                    {
                        _loginRequest = true;
                        Console.WriteLine("Wrong PIN - Redirecting to start\n======================================\n");
                        return;
                    }
                }
                else
                {
                    _loginRequest = true;
                    Console.WriteLine("There is no account associated with this number.\n");
                    return;
                }
            }
        }

        private void Menu(Account account) 
        {
            MenuMessage(account);

            bool loopContinue = true;
            while (loopContinue)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        ShowBalance(account);
                        loopContinue = true;
                        MenuMessage(account);
                        break;
                    case "2":
                        Deposit(account);
                        loopContinue = true;
                        MenuMessage(account);
                        break;
                    case "3":
                        Withdraw(account);
                        loopContinue = true;
                        MenuMessage(account);
                        break;
                    case "4":
                        AccountDetails(account);
                        loopContinue = true;
                        MenuMessage(account);
                        break;
                    case "5":
                        loopContinue = false;
                        _loginRequest = true;
                        break;
                    case "6":
                        loopContinue = false;
                        _loginRequest = false;
                        break;
                    default:
                        Console.Write("Wrong option please choose again: ");
                        loopContinue = true;
                        break;
                }
            }
            return;
        }

        private void MenuMessage(Account account)
        {
            Console.WriteLine($"\nWelcome {account.FirstName}!\n======================================\n");
            Console.WriteLine("Choose option:\n");
            Console.WriteLine("1 - Show Balance\n2 - Deposit\n3 - Withdraw\n4 - Account Details\n5 - Log in to another acoount\n6 - Exit ATM");
        }
        private void ShowBalance(Account account) 
        {
            Console.WriteLine($"======================================\n======================================\nYour current balance is: {Math.Round(account.Balance, 2)} $");
            return;
        }
        private void Deposit(Account account) 
        {
            Console.Write("Enter amount to deposit: ");
            string input = Console.ReadLine();

            while (!double.TryParse(input, out _) || Convert.ToDecimal(input) <= 0 || (Math.Round(Convert.ToDecimal(input), 2)) != Convert.ToDecimal(input))
            {
                Console.Write("Enter a correct amount: ");
                input = Console.ReadLine();
            }
            account.Balance += Math.Round(Convert.ToDecimal(input), 2);
            Console.WriteLine($"======================================\n======================================\nYou deposited {Math.Round(Convert.ToDecimal(input), 2)} $");
        }
        private void Withdraw(Account account) 
        { 
            Console.Write("Enter amount to withdraw: ");
            string input = Console.ReadLine();

            while (!double.TryParse(input, out _) || Convert.ToDecimal(input) <= 0 || (Math.Round(Convert.ToDecimal(input), 2)) != Convert.ToDecimal(input))
            {
                Console.Write("Enter a correct amount: ");
                input = Console.ReadLine();
            }
            if(Convert.ToDecimal(input) > account.Balance)
            {
                Console.WriteLine("Not enough funds.");
            }
            else
            {
                account.Balance -= Math.Round(Convert.ToDecimal(input), 2);
                Console.WriteLine($"======================================\n======================================\nYou withdrawed {Math.Round(Convert.ToDecimal(input), 2)} $");
            }
        }
        private void AccountDetails(Account account) 
        {
            Console.WriteLine("======================================\n======================================\nAccount Details:");
            Console.WriteLine($"First Name: {account.FirstName}\nLast Name: {account.LastName}\nDate of Birth: {account.DateOfBirth:dd/MM/yyyy}");
        }
    }
}
