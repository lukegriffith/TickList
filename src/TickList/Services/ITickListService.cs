using System.Collections.Generic;
using TickList.Models;

namespace TickList.Services
{
    public interface ITickListService
    {
        //List<TickItem> TickList { get; set; }

        TickItem GetItem(int id);
        List<TickItem> GetList();
        void NewItem(string Title);
        void ModifyItem(int id, TickItem item);
        void RemoveItem(int id);
    }
}