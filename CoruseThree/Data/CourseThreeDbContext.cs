using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;            
                                         
namespace CoruseThree.Data
{
    public class CourseThreeDbContext : IdentityDbContext
    {

        // this is very imprtant --------------------------------
        public CourseThreeDbContext(DbContextOptions<CourseThreeDbContext> options) : base(options)
        {
                
        }
    }
}
