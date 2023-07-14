using assignment_1_mervegokGH.Model;
using FluentValidation;

namespace assignment_1_mervegokGH.Validator
{
    public class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Staf person cannot be empty")
                    .Length(5, 100).WithMessage("Staff person name must be a minimum of 5 characters and a maximum of 100 characters");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Last name cannot be empty")
                    .Length(5, 100).WithMessage("Last name must be a minimum of 5 characters and a maximum of 100 characters");
            RuleFor(x=>x.Phone).NotEmpty().WithMessage("Phone number cannot be empty")
                    //using regex. in this code ensuring that the input consists of exactly 10 digits.
                    .Matches(@"^[0-9]{10}$").WithMessage("Please enter a valid phone number.");
            RuleFor(x => x.AccessLevel)
            .InclusiveBetween(1, 5).WithMessage("Staff person access level to system must be between 1 and 5.");

            RuleFor(x => x.Salary)
            .Must((person, salary) => Salary(person.AccessLevel, salary))
            .WithMessage("Salary is not valid for the current access level.")
            .InclusiveBetween(5000, 50000).WithMessage("Staff person salary must  min 5000 and max 50000.");
        }
        //It checked the access level and salary entered by the user together.
        private bool Salary(int accessLevel, decimal salary)
        {
            if (accessLevel == 1 && salary <= 10000)
                return true;

            if (accessLevel == 2 && salary <= 20000)
                return true;

            if (accessLevel == 3 && salary <= 30000)
                return true;

            if (accessLevel == 4 && salary <= 40000)
                return true;

            if (accessLevel == 5 && salary <= 50000)
                return true;

            return false;
        }
    }
 }

