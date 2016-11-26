using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickList.Models;

namespace TickList.Services
{
    public class TickListService : ITickListService
    {


        public List<TickItem> TickList { get; set; }


        public TickListService()
        {
            
            TickList = new List<TickItem>();

        }

        public TickItem GetItem(int id)
        {
            return TickList.Where(i => i.TickItemID == id).First<TickItem>();
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

    }
}
