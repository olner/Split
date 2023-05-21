using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Models
{
    public record Friend
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public bool Request { get;set; }
    }
}
