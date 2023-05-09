using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.DbContexts.Tables
{
    [Table("user_roles")]
    public record UserRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("role_id")]
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public Roles Roles { get; set; }
        [Column("user_id")]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public Users Users { get; set; }


    }
}
