using huzcodes.Persistence.Implementations.EfRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Infrastructre.Data
{
    internal class InventoryRepository<TEntity>: HuzcodesRepository<TEntity> where TEntity : class
    {
        public InventoryRepository(AppContextDb appContextDb):base(appContextDb)
        {
            
        }
    }
}
