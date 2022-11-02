using System.ComponentModel.DataAnnotations;

namespace Lab2.DAL.Models.User
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Not specified user name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Not specified email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Not specified password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Not confirmed password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
