using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockExchange_Chatbot_Backend.ReadModel.Entities
{
    public class UserHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserHistoryId { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
