using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Split.DbContexts.Tables
{
    public record Friends
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("user_id")]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users Users { get; set; }

        [Column("friend_id")]
        [ForeignKey("Friends")]
        public int FriendId { get; set; }
        public Users Friend { get; set; }

        public bool Request { get; set; }

    }
}
