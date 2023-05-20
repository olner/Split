using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Split.DbContexts.Tables
{
    [Table ("users")]
    public record Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }

        public ICollection<UserRoles> userRoles { get; set; }
        public ICollection<GroupsMembers> groupsMembers { get; set; }
    }
}
