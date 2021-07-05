using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dtos
{
    public class AdminDto
    {
        public int AdminId { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }
        public bool AdminStatus { get; set; }

    }
}
