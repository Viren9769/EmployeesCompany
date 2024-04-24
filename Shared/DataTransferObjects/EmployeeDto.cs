using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shared.DataTransferObjects
{
    public record EmployeeDto(Guid Id, string Name, int Age, string Position);

    // we get 500 Internal Server error which is a generic message . this mean that the server made error.
    // This means that the server made an error, which is not the case. In 
    //this case, we, as a consumer, sent the wrong model to the API — thus the
    //error message should be different.
    //To fix this, let’s modify our EmployeeForCreationDto record because
    //that’s what we deserialize the request body to:

    public record EmployeeForCreationDto : EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; init; }
        [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string? Position { get; init; }
    }

    public record EmployeeForUpdateDto : EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
       
        public string? Name { get; init; }
       [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
       public int Age { get; init; }

       [Required(ErrorMessage = "Position is a required field.")]
      [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string? Position { get; init; }
}


    public abstract record EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; init; }
        [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
        public int Age { get; init; }
        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20  characters.")]
        public string? Position { get; init; }
    }
}



    
