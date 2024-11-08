using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstMVCApp.ViewModel
{
    
    public class UserViewModel
    {
        public int UserViewModelID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }

        //public int CountryID { get; set; }


    }
}
