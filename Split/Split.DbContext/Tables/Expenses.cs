using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Split.DbContexts.Tables
{
    public record Expenses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Column("user_id")]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users Users { get; set; }

        [Column("group_id")]
        [ForeignKey("Groups")]
        public Guid GroupId { get; set; }
        public Groups Groups { get; set; }

        public double Sum { get; set; }

        public DateTime Date { get; set; }
        
    }
}
