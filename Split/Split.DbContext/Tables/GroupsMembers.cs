using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.DbContexts.Tables
{
    [Table("groups_members")]
    public record GroupsMembers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("group_id")]
        [ForeignKey("Groups")]
        public Guid GroupId { get; set; }
        public Groups Groups { get; set; }

        [Column("user_id")]
        [ForeignKey("Users")]
        public int UserID { get; set; }
        public Users Users { get; set; }
    }
}
