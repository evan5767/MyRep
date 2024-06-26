using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Sushi.Data.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
