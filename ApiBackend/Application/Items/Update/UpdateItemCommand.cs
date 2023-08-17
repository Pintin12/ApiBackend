using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Update
{
    public record UpdateItemCommand(
        Guid Id,
        string itemDescription,
        bool itemState) : IRequest<ErrorOr<Unit>>;
}
