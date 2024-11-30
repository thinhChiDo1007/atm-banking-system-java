//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Task_xy
//{
//    public class User
//    {
//        public string UserName { get; set; }
//        public string Password { get; set; }
//        public string Email { get; set; }
//    }
//    internal class Bank
//    {
//        public Bank()
//        {
//            users.Add(new User()
//            {
//                UserName = "Joe.Doe",
//                Password = "Password123"
//            });
//        }
//        List<User> users = new List<User>();
//        /// <summary>
//        /// login
//        /// </summary>
//        /// <param name="Username"></param>
//        /// <param name="Password"></param>
//        /// <returns></returns>
//        public bool Login(string Username, string Password)
//        {
//            foreach (var user in users)
//            {
//                if (user.UserName == Username && user.Password == Password  )
//                {
//                    return true;
//                }
//                else
//                {
//                    continue;
//                    //return false;
//                }
//            }
//            return false;
//        }
//        /// <summary>
//        /// signup
//        /// </summary>
//        /// <param name="username"></param>
//        public void signup(string username, string email, string age, string phone, string password)
//        {
//            users.Add(new User 
//            { 
//                UserName = username,
//                Password = password,
//            });
//        }

//    }
//}

