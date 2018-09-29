using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short Fee { get; set; }
        public string Name { get; set; }
        public byte NumMonths { get; set; }
        public byte Discount { get; set; }
    }
}