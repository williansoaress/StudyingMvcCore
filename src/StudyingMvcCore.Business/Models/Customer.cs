using System.Collections.Generic;

namespace StudyingMvcCore.Business.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        /*EF Relation*/
        public IEnumerable<ToDo> ToDos { get; set; }
    }
}
