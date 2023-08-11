using Domain.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Item item) => _context.Items.Add(item);
        public void Update(Item item) => _context.Update(item);
        public async Task<bool> ExistsAsync(ItemId id) => await _context.Items.AnyAsync(x => x.Id == id);
        public async Task<List<Item>> GetAllAsync() => await _context.Items.ToListAsync();
              
    }
}
