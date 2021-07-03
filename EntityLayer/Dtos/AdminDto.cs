using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AdminDto
    {
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }
        public bool AdminStatus { get; set; }

    }
}
