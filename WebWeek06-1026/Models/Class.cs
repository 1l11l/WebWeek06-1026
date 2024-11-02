// 建立用來對應資料表Member的類別
namespace WebWeek06_1026.Models
{
    public class Member
    {
        public Guid Mid { get; set; } = Guid.NewGuid();                 // 自動生成唯一識別碼
        public string Mname { get; set; } = string.Empty;               // 必填，姓名 (初始化屬性的預設值為空字串，string.Empty 等於 "")
        public int Mage { get; set; }                                   // 必填，年齡
        public bool Mverified { get; set; }                             // 必填，是否通過會員驗證
        public string? Mphone { get; set; }                             // 選填，電話欄位
        public DateTime MregistrationDate { get; set; } = DateTime.Now; // 註冊日期，初始化為當下時間
    }

}

// { get; set; }
// 可以讀取和修改屬性的值。