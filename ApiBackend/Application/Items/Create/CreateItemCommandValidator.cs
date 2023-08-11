using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Create
{
    public class CreateItemCommandValidator :AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator() { 
            RuleFor(r => r.ItemDescription)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
