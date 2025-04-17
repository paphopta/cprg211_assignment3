using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    public class Node
    {
        public User user;
        public Node Next { set; get; }
        public Node(User user)
        {
            this.user = user;
        }
    }
}
