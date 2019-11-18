using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Supplier.API.Model
{
    public class Supplier : IValidatableObject
    {

        public Supplier(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public String Name { get; set; }

        public String FullName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            var results = new List<ValidationResult>();

             if (string.IsNullOrWhiteSpace(Name))
             {
                 results.Add(new ValidationResult("Name must be set.", new []{ nameof(Name) }));
             }

            return results;
        }
    }
}
