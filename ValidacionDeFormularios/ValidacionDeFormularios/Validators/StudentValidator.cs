using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ValidacionDeFormularios.Models;

namespace ValidacionDeFormularios.Validators
{
    public class StudentValidator: AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(X => X.Email).EmailAddress();
            RuleFor(x => x.Score).LessThan(11);
        }
    }
}
