using System.ComponentModel.DataAnnotations;

namespace CoruseThree.Models.ViewModel
{
    public class ViewLoginModel 
    {

        [Required]
        [EmailAddress]
         public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password  { get; set; }

        public bool RememberMe { get; set; }

    }
}
