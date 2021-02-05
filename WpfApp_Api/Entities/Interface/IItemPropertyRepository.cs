using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IItemPropertyRepository
    {
        Task<IEnumerable<ItemProperty>> GetItems(int ListID);
        Task InsertItem(ItemProperty ItemProperty);
        Task UpdateItem(ItemProperty ItemProperty);
        Task DeleteItemByID(int ItemID);
        Task DeleteItemByListID(int ListID);
        Task Save();
    } 

}
