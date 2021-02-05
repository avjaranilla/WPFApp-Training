using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IListPropertyRepository
    {
        Task<IEnumerable<ListProperty>> GetLists();

        Task InsertList(ListProperty ListProperty);
        Task Save();
        Task DeleteList(int ListID);
        Task UpdateList(ListProperty ListProperty);
    }
}
