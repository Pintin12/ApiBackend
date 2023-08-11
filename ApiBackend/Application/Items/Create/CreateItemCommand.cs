using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Create
{
    public record CreateItemCommand(
        string ItemDescription
        ): IRequest<ErrorOr<Guid>>;
    
}
