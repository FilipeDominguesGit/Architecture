using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Domain.Models
{
    public class User
    {
        public int Id { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
