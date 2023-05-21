using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.DbContexts.Tables
{
    [Table("groups")]
    public record Groups
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }

        [Column("admin")]
        [ForeignKey("Users")]
        public int Admin { get; set; }
        public Users Users { get; set; }

        public ICollection<GroupsMembers> groupsMembers { get; set; }
    }
}
