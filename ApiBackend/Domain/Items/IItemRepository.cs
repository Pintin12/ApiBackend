namespace Domain.Items
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<bool> ExistsAsync(ItemId id);
        void Add(Item item);
        void Update(Item item);
      
    }
}
