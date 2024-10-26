namespace WebWeek06_1026.Models
{
    public class Member
    {
        public Guid Mid { get; set; } = Guid.NewGuid();    // 自動生成唯一識別碼
        public string Mname { get; set; } = string.Empty;   // 最多 10 字元，必填
        public int Mage { get; set; }                       // 必填
        public bool Mverified { get; set; }                 // 必填的布林值
        public string? Mphone { get; set; }                 // 選填，電話欄位
    }

}
