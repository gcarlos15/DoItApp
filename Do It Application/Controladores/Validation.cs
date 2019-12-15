using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoIt.Controladores
{
    sealed class Validation
    {
        private ValidationContext validationContext;
        private List<ValidationResult> validationResults = new List<ValidationResult>();

        public bool Validate(object modelo)
        {
            validationContext = new ValidationContext(modelo);
            bool feedBack = Validator.TryValidateObject(modelo, validationContext, validationResults, true);
        
            return feedBack;
        }

        public List<ValidationResult> getErrorMessages ()
        {
            return validationResults;
        }
    }
}
