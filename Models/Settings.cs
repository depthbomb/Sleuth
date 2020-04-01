using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleuth.Models
{
    public class Settings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Browser { get; set; } = "chrome";
    }

}
