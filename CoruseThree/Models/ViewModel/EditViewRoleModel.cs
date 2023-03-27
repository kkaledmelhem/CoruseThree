using Microsoft.Build.Framework;
using System.Security.Policy;

namespace CoruseThree.Models.ViewModel
{
    public class EditViewRoleModel
    {

        public EditViewRoleModel()
        {


            UserName = new List<string>();
        }

        public string RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }

        public List<string> UserName { get; set; }
    }
}
