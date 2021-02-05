using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfAppUi_Entities.Entities;

namespace WpfAppUi_Entities.Interface
{
    public interface IListPropertyResponseObjRepo
    {
        Task<IEnumerable<ListPropertyResponseObj>> GetLists();
        Task<string> InsertList(ListPropertyResponseObj ListPropertyResponseObj);
        Task<string> UpdateList(ListPropertyResponseObj ListPropertyResponseObj);
        Task<string> Deletelist(int ListID);
    }
}