using Application.Items.Common;
using Domain.Items;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.GetAll
{
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, ErrorOr<IReadOnlyList<ItemResponse>>>
    {
        private readonly IItemRepository _itemRepository;

        public GetAllItemsQueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<ItemResponse>>> Handle(GetAllItemsQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Item> items = await _itemRepository.GetAllAsync();

            return items.Select(item => new ItemResponse(
                    item.Id.Value,
                    item.ItemDescription,
                    item.ItemState
                    )).ToList();
        }
    }

}
