using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.DbContexts.Tables
{
    public record UserRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("role_id")]
        [ForeignKey("role_id_FK")]
        public int RoleId { get; set; }
        [Column("user_id")]
        [ForeignKey("user_id_FK")]
        public int UserId { get; set; }

        public Roles Roles { get; set; }
        public Users Users { get; set; }
    }
}
