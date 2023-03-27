using System.ComponentModel.DataAnnotations;

namespace CoruseThree.Models.ViewModel
{
    public class ViewRigisterModel
    {
        //here soem important information
    

        [Required]
        [EmailAddress(ErrorMessage ="User@domain.com")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
       
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="Not Match password")]

        public string CofirmedPassword { get; set; }

        [Phone]
        public string MoblieNumber { get; set; }


    }
}
