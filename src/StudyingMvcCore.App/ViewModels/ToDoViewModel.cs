using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudyingMvcCore.App.ViewModels
{
    public class ToDoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public CustomerViewModel Customer { get; set; }

        public IEnumerable<CustomerViewModel> Customers { get; set; }
    }
}
