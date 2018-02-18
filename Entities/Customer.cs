using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }  // navigation property
        public string Gender { get; set; }
    }
}
