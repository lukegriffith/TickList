using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickListLinux.Models
{
    public class TickItem
    {

        public int TickItemID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public DateTime Created { get; set; }

        public TickItem(int id, string TickTitle)
        {
            TickItemID = id;
            Title = TickTitle;
            Completed = false;
            Created = DateTime.Now;
        }

    }
}
