using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UserLogin.DAL;
using UserLogin.Entity;

namespace UserLogin.BL
{
    public class ManageUser
    {
        UserDAL userCRUD = new UserDAL();
        public bool AuthenticateUser(string username, string password)
        {
            Users user = new Users();
            user.UserName = username;
            user.Password = password;
            user.Email = username;

            string res = userCRUD.ValidateUser(user);
            if (res =="true")   return true; else return false;
            
        }
        public void AddUser()
        {
            string email;
            while (true)
            {
                Users user = new Users();
                Console.WriteLine("Enter User Name");
                user.UserName = Console.ReadLine();
                Console.WriteLine("Enter Password");
                user.Password = Console.ReadLine();
                Console.WriteLine("Enter Email");
                while (true)
                {
                    
                    email = Console.ReadLine();
                    if (Validate_emailAddress(email) == false) 
                    { Console.WriteLine("Enter a valid Email :"); } 
                    else { break; }

                }
                user.Email = email;

                bool result = userCRUD.Create(user);
                if (result == true)
                {
                    Console.WriteLine("User Added Successfully");
                    ListUsers();
                    break;
                }
                else
                {
                    Console.WriteLine("Error Occured . Try Again");
                }
            }
        }
        public void RemoveUser()
        {
            while (true)
            {
                Console.WriteLine("Enter User Id to Delete");
                int id = Convert.ToInt16(Console.ReadLine());
                bool result = userCRUD.DeleteById(id);
                if (result == true)
                {
                    Console.WriteLine("Grade Deleted Successfully");
                    ListUsers();
                    break;

                }
                else
                {
                    Console.WriteLine("Error Occured . Try Again");
                }
            }
        }

        public void ListUsers()
        {
            List<Users> lstuser = new List<Users>();

            lstuser = userCRUD.GetAll();

            Console.WriteLine("Id - Name - Email");
            foreach (var user in lstuser)
            {
                Console.WriteLine($"{user.UserId} - {user.UserName} - {user.Email}");
            }
            
        }


        public bool Validate_emailAddress(string emailAddress)
        {
            try
            {
                var email = new MailAddress(emailAddress);
                return email.Address == emailAddress.Trim();
            }
            catch
            {
                return false;
            }
        }
    }
}
