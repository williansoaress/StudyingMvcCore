using System;
using System.Collections.Generic;
using System.Text;

namespace StudyingMvcCore.Business.Models
{
    public class Address : Entity
    {
        public Guid CustomerId { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public Customer Customer { get; set; }
    }
}
