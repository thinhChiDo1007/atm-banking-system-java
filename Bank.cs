using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_xy
{
    
    public class Bank
    {

        public List<User> users = new List<User>();
        public int WithdrawCount = 0;

        public Bank()
        {
            users.Add(new User()
            {
                UserName = "Joe.Doe",
                Password = "Password123"
            });

            users.Add(new User()
            {
                UserName = "1",
                Password = "1"
            });
        }



        public User Login(string userName, string password)
        {

            foreach (var user in users)
            {
                if (user.UserName == userName && user.Password == password)
                {
                    return user;
                }
                else
                {
                    continue;
                }
            }
            return null;
        }


        public void Signup(string username, string password)
        {
            users.Add(new User
            {
                UserName = username,
                Password = password,
            });
        }

        public void Deposit(decimal amount, User user)
        {
            user.Balance += amount;
        }

        public Boolean WithdrawAllowed()
        {
            return WithdrawCount < 5;
        }

        public Boolean Withdraw(decimal amount, User user)
        {
            if (user.Balance >= amount)
            {
                user.Balance -= amount;
                WithdrawCount++;
                return true;
            } else
            {
                return false;
            }
        }

    }
}
