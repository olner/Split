using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Models
{
    public record GroupMember
    {
        public int Id { get; set; }
        public Guid GroupId { get; set; }
        public int UserId { get; set; }

    }
}
