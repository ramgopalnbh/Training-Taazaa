using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class staff
    {
        public object staffs;

        public long staffId { get; set; }
        public long RoleId { get; set; }
        public long AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }
        public Address Address { get; set; }


    }
}
