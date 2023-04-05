using Microsoft.AspNetCore.Mvc;
using Black.Zinc.Spitz.Domain.Catalog;

namespace Black.Zinc.Spitz.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {

         [HttpGet]
         public IActionResult GetItems()
         {
             var items = new List<Item>()
             {
               new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m),
               new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
             };
    
             return Ok(items);
         }

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


         [HttpPost]
         public IActionResult Post(Item item)
         {
            _db.Items.Add(item);
            _db.SavedChanges();
            return Created($"/catalog/{item.Id}", item);
         }

         //step 5 code starts
         [HttpPost("{id:int}/ratings")]
         public IActionResult PostRating(int id, [FromBody] Rating rating)
         {
            var item = new Item("Shirt", "Ohio State Shirt.", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);

            return Ok(item);
         }
         //step 5 code ends

         //step 6 code starts
         [HttpPut("{id:int}")]
         public IActionResult Put(int id, Item item)
         {
            return NoContent();
         }
         //step 6 code ends

         //step 7 code starts
         [HttpDelete("{id:int}")]
         public IActionResult Delete(int id)
         {
            return NoContent();
         }
    }

}
