using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickList.Models;

namespace TickList.Services
{
    public class TickListService : ITickListService
    {


        private List<TickItem> TickList { get; set; }


        public TickListService()
        {
            
            TickList = new List<TickItem>();

        }

        public TickItem GetItem(int id)
        {
            try
            {
                return TickList.Where(i => i.TickItemID == id).First<TickItem>();
            }
            catch
            {
                // returns a null tick item if not found.
                return new TickItem(0, "");
            }
        }

        public List<TickItem> GetList()
        {
            return TickList;
        }

        public void NewItem(string Title)
        {
            int HighestID; 
            var IdList = TickList.Select(i => i.TickItemID).ToList<int>();

            IdList.Sort();

            try
            {
                HighestID = IdList.Last<int>();

            }
            catch
            {
                HighestID = 0;
            }
            int NewID = HighestID + 1;

            TickItem newItem = new TickItem(NewID, Title);
            TickList.Add(newItem);

        }

        public void ModifyItem(int id, TickItem item)
        {
            TickItem oldItem = TickList.Where(i => i.TickItemID == id).Single<TickItem>();
            int index = TickList.IndexOf(oldItem);
            TickList[index] = item;
        }

        public void RemoveItem(int id)
        {
            TickItem item = TickList.Where(i => i.TickItemID == id).Single<TickItem>();
            TickList.Remove(item);
        }

    }
}
