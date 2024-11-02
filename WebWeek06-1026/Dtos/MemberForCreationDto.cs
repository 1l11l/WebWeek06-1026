using System;
using System.ComponentModel.DataAnnotations;

namespace WebWeek06_1026.Dtos
{
    public class MemberForCreationDto
    {
        [Required]  // 必填
        [StringLength(10, ErrorMessage = "姓名最多 10 個字")]
        public string Mname { get; set; } 

        [Required]
        [Range(0, 120, ErrorMessage = "年齡必須在 0 到 120 之間")]
        public int Mage { get; set; }    

        [Required]
        public bool Mverified { get; set; }

        [StringLength(10, ErrorMessage = "電話號碼最多 10 個數字")]
        public string? Mphone { get; set; }

        public DateTime MregistrationDate { get; set; } = DateTime.Now;

    }
}
