using Microsoft.Build.Framework;

namespace CoruseThree.Models.ViewModel
{
    public class CreateRoleModelView
    {
        [Required]

        public string RoleName { get; set; }
        public int MyProperty { get; set; }
    }
}
