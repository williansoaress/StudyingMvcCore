using System;

namespace StudyingMvcCore.Business.Models
{
    public class ToDo : Entity
    {
        public Guid CustomerId { get; set; }

        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        /*EF Relation*/
        public Customer Customer { get; set; }
    }
}
