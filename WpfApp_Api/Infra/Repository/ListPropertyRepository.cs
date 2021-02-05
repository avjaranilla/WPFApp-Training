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
    public class ListPropertyRepository : IListPropertyRepository
    {
        private readonly WpfAppApiContext _context;

        public ListPropertyRepository(WpfAppApiContext context)
        {
            _context = context;
        }

        
        /// <summary>
        /// Get all list.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ListProperty>> GetLists()
        {
            return  await _context.ListProperty.ToListAsync();
        }

      /// <summary>
      ///  Add new list
      /// </summary>
      /// <param name="ListProperty"></param>
      /// <returns></returns>
        public async Task InsertList(ListProperty ListProperty)
        { 
            _context.ListProperty.Add(ListProperty);
            await Save();
        }

      /// <summary>
      /// Update selected list
      /// </summary>
      /// <param name="ListProperty"></param>
      /// <returns></returns>
        public async Task UpdateList(ListProperty ListProperty)
        {
            GetSelectedListProperty(ListProperty.ListID);
            AssignedValuesListProperty(ListProperty);
            await Save();
        }
        
        /// <summary>
        /// Delete Selected List
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public async Task DeleteList(int ListID)
        {
            var listProperty = GetSelectedListProperty(ListID);
            _context.ListProperty.Remove(listProperty);
            await Save();
        }


        /// <summary>
        /// Save Transaction
        /// </summary>
        /// <returns></returns>
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        #region OtherMethods

        /// <summary>
        /// Get Selected List and Return as ListProperty Object
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public ListProperty GetSelectedListProperty(int ListID)
        {
            var ListProperty = _context.ListProperty.First(lp => lp.ListID == ListID);
            return ListProperty;
        }

        /// <summary>
        /// Assigned new value for the selected ListProperty
        /// </summary>
        /// <param name="ListProperty"></param>
        public void AssignedValuesListProperty(ListProperty ListProperty)
        {
            var listProperty = GetSelectedListProperty(ListProperty.ListID);
            listProperty.ListName = ListProperty.ListName;
            listProperty.ListDesc = ListProperty.ListDesc;
        }
        #endregion

    }
}
