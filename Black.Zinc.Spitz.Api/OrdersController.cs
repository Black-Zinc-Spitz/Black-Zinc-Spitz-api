using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Black.Zinc.Spitz.Domain.Catalog;
using Black.Zinc.Spitz.Data;
using Microsoft.EntityFrameworkCore;

namespace Black.Zinc.Spitz.Api
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly StoreContext _db;

       public OrdersController(StoreContext db)
       {
            _db = db;
       }

         //added old version back in after looking at the examples
         [HttpGet]
         public IActionResult GetItems()
         {
             return Ok(_db.Items);
         }

         // step 3 not sure where it goes or if it ovverides the old version so i will add it here
         [HttpGet("{id:int}")]
         public IActionResult GetItem(int id)
         {
             var item = _db.Items.Find(id);
             if (item == null)
             {
               return NotFound();
             }
             return Ok();
         }
         //end of step 3 code


         //Step 4 states to add this here 
         [HttpPost]
         public IActionResult Post(Item item)
         {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
         }
         //end of step 4 code

         

         //step 6 code starts
         [HttpPut("{id:int}")]
         public IActionResult PutItem(int id, [FromBody] Item item)
         {
            if (id != item.Id)
            {
               return BadRequest();
            }
               if (_db.Items.Find(id) == null)
            {
               return NotFound();
            }

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            
            return NoContent();
         }
         //step 6 code ends

         //step 7 code starts
         [HttpDelete("{id:int}")]
         public IActionResult DeleteItem(int id)
         {
            var item = _db.Items.Find(id);
            if (item == null)
            {
               return NotFound();
            }
            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();
         }
    }
}
