using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TickList.Services;
using TickList.Models;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TickList.Controllers
{
    [Route("api/[controller]")]
    public class TickController : Controller
    {

        
        ITickListService _tickService { get; set; }


        public TickController(ITickListService tickServ)
        {
            _tickService = tickServ;
        }

        // GET: api/values
        [HttpGet]
        public List<TickItem> Get()
        {


            //_tickService.NewItem("NewTickItem");
            //_tickService.NewItem("NewTickItem1");

            return _tickService.GetList();

            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TickItem Get(int id)
        {
            return _tickService.GetItem(id);
        }

        // POST api/values
        // Body string needs to be converted from string to json (ConvertFrom-Json)
        [HttpPost]
        public void Post([FromBody]String value)
        {

            //Console.WriteLine("String value is |{0}|", value);
            _tickService.NewItem(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TickItem item)
        {

            _tickService.ModifyItem(id, item);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tickService.RemoveItem(id);
        }
    }
}
