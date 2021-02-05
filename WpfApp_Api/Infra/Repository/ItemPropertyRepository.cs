using Entities.Interface;
using Entities.Model;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class ItemPropertyRepository : IItemPropertyRepository
    {
        private readonly WpfAppApiContext _context;

        public ItemPropertyRepository(WpfAppApiContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all items on a  List
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ItemProperty>> GetItems(int ListID)
        {
            return await _context.ItemProperty.Where(i => i.ListID == ListID).ToListAsync();
        }


        /// <summary>
        /// Insert new item for a list
        /// </summary>
        /// <param name="ItemProperty"></param>
        /// <returns></returns>
        public async Task InsertItem(ItemProperty ItemProperty)
        {
            _context.ItemProperty.Add(ItemProperty);
            await Save();
        }

        /// <summary>
        /// Update selected item 
        /// </summary>
        /// <param name="ItemProperty"></param>
        /// <returns></returns>
        public async Task UpdateItem(ItemProperty ItemProperty)
        {
            GetSelectedItemPropertyByItemID(ItemProperty.ItemID);
            AssignedValuesItemProperty(ItemProperty);
            await Save();
        }
        
        /// <summary>
        /// Delete selected item
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public async Task DeleteItemByID(int ItemID)
        {
            var itemProperty = GetSelectedItemPropertyByItemID(ItemID);
            _context.ItemProperty.Remove((ItemProperty)itemProperty);
            await Save();
        }

        /// <summary>
        /// Delete all item on a particular list
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public async Task DeleteItemByListID(int ListID)
        {
            var itemProperty = GetSelectedItemPropertyByListID(ListID);
            _context.ItemProperty.RemoveRange(itemProperty);
            await Save();
        }

        public async Task Save()
        {
             await _context.SaveChangesAsync();
        }

        #region OtherMethods
        /// <summary>
        /// Get selected item and return as ItemProperty object
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public ItemProperty GetSelectedItemPropertyByItemID (int ItemID)
        {
            var itemProperty = _context.ItemProperty.First(ip => ip.ItemID == ItemID);
            return itemProperty;
        }

        /// <summary>
        /// Get selected all items and return as Enumerable
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public IEnumerable<ItemProperty> GetSelectedItemPropertyByListID(int ListID)
        {
            var itemProperty = _context.ItemProperty.Where(lp => lp.ListID == ListID);
            return itemProperty;
        }

        /// <summary>
        /// Assigned values for a selected item
        /// </summary>
        /// <param name="ItemProperty"></param>
        public void AssignedValuesItemProperty (ItemProperty  ItemProperty)
        {
            var itemProperty = GetSelectedItemPropertyByItemID(ItemProperty.ItemID);
            itemProperty.ItemName = ItemProperty.ItemName;
            itemProperty.ItemDesc = ItemProperty.ItemDesc;
            itemProperty.ItemStatus = ItemProperty.ItemStatus;
        }
        #endregion
    }
}
