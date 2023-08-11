using Domain.Primitivies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Items
{
    public sealed class Item : AggregateRoot
    {

        public Item(ItemId id, string itemDescription, bool itemState)
        {
            Id = id;
            ItemDescription = itemDescription;
            ItemState = itemState;
        }

        public Item() { }

        public ItemId Id { get; private set; }
        public string ItemDescription { get; private set; }
        public bool ItemState { get; private set; }
        
        public static Item UpdateItem(Guid id, string itemDescription, bool itemState)
        {
            return new Item(new ItemId(id),itemDescription, itemState);
        }
    }
}
