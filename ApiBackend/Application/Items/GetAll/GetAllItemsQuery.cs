using Application.Items.Common;
using ErrorOr;
using MediatR;

namespace Application.Items.GetAll
{
    public record GetAllItemsQuery():IRequest<ErrorOr<IReadOnlyList<ItemResponse>>>;
    
}
