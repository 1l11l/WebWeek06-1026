using System.ComponentModel.DataAnnotations;

namespace WebWeek06_1026.Dtos
{
    public class MemberForUpdateDto
    {
        [Required]
        [StringLength(10, ErrorMessage = "姓名最多 10 個字")]
        public string Mname { get; set; }

        [Required]
        public int Mage { get; set; }

        [Required]
        public bool Mverified { get; set; } 

        [StringLength(10, ErrorMessage = "電話號碼最多 10 個數字")]
        public string? Mphone { get; set; }

        public DateTime MregistrationDate { get; set; } = DateTime.Now;
    }
}
