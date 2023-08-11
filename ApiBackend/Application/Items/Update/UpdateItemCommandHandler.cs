using Domain.Items;
using Domain.Primitivies;
using ErrorOr;
using MediatR;

namespace Application.Items.Update
{
    internal sealed class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ErrorOr<Unit>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateItemCommandHandler(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(UpdateItemCommand itemUpdate, CancellationToken cancellationToken)
        {
            if (!await _itemRepository.ExistsAsync(new ItemId(itemUpdate.Id)))
            {
                return Error.NotFound("Item.NotFound", "The ToDo with the provide Id was not found.");
            }

            Item item = Item.UpdateItem(itemUpdate.Id, itemUpdate.itemDescription,
                itemUpdate.ItemState);

            _itemRepository.Update(item);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
