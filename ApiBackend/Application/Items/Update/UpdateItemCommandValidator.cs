using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Update
{
    public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
    {
        public UpdateItemCommandValidator() { 
            RuleFor(r=> r.Id).NotEmpty();
            RuleFor(r=>r.itemDescription).NotEmpty();
            RuleFor(r=>r.ItemState).NotEmpty();
        }
    }
}
