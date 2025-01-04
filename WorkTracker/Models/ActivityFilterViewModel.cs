using System.ComponentModel.DataAnnotations;

namespace WorkTracker.Models
{
    public class ActivityFilterViewModel
    {
        [Required(ErrorMessage = "Data początkowa jest wymagana.")]
        public DateOnly? StartDate { get; set; }

        [Required(ErrorMessage = "Data końcowa jest wymagana.")]
        public DateOnly? EndDate { get; set; }

        [CompareDates(ErrorMessage = "Data początkowa nie może być późniejsza niż data końcowa.")]
        public bool IsDateRangeValid => StartDate <= EndDate;
    }

    public class CompareDatesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var model = (ActivityFilterViewModel)validationContext.ObjectInstance;

            if (model.StartDate > model.EndDate)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success!;
        }
    }
}