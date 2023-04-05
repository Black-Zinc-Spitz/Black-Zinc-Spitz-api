using Microsoft.AspNetCore.Mvc;
using Black.Zinc.Spitz.Domain.Catalog;
using Black.Zinc.Spitz.Data;

namespace Black.Zinc.Spitz.Api.Controllers
{
    [ApiController]
    [Route("/catalog")]
    public class CatalogController : ControllerBase
    {

      private readonly StoreContext _db;

      public CatalogController(StoreContext db)
      {
         _db = db;

         [HttpGet]
         public IactionResult GetItems()
         {
            return Ok(_db.Items);
         }
      }


         //added old version back in after looking at the examples
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
         //end of alteration
         
         
         // step 3 not sure where it goes or if it ovverides the old version so i will add it here
         [HttpGet("{id:int}")]
         public IActionResult GetItem(int id)
         {
             var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
              item.Id = id;
    
             return Ok(item);
         }
         //end of step 3 code


         //Step 4 states to add this here 
         [HttpPost]
         public IActionResult Post(Item item)
         {
            return Created("/catalog/42", item);
         }
         //end of step 4 code

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
