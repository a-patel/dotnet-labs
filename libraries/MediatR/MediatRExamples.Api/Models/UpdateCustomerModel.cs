#region Imports
using System;
using System.ComponentModel.DataAnnotations;
#endregion

namespace MediatRExamples.Api.Models
{
    public class UpdateCustomerModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Age { get; set; }

        public string Phone { get; set; }
    }
}
