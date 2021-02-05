using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfAppUi_Entities.Entities;

namespace WpfAppUi_Entities.Interface
{
    public interface IItemPropertyResponseObjRepo
    {
        Task<IEnumerable<ItemPropertyResponseObj>> GetItems(int ListID);
        Task<string> InsertItem(ItemPropertyResponseObj ItemPropertyResponseObj);
        Task<string> UpdateItem(ItemPropertyResponseObj ItemPropertyResponseObj);
        Task<string> DeleteItemByItemID(int ItemID);
        Task<string> DeleteItemByListID(int ListID);



    }
}
