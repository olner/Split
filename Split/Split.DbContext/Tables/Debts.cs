using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Split.DbContexts.Tables
{
    public record Debts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("expense_id")]
        [ForeignKey("Users")]
        public Guid ExpenseId { get; set; }
        public Expenses Expenses { get; set; }

        [Column("user_id")]
        [ForeignKey("Users")]
        public int UserId { get; set; }

        public Users Users { get; set; }

        public double Debt { get;set; }

        public double Paid { get;set; }
    }
}
