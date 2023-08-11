using Domain.Items;
using Domain.Primitivies;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Create
{
    public sealed class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, ErrorOr<Guid>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateItemCommandHandler(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Guid>> Handle(CreateItemCommand command, CancellationToken cancellationToken)
        {

            var item = new Item(
                new ItemId(Guid.NewGuid()),
                command.ItemDescription,
                false
            );

            _itemRepository.Add(item);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return item.Id.Value;
        }
    }
}
