using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BucketList.Model;

namespace BucketList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketListController : ControllerBase
    {
        private readonly BucketItemContext _context;

        public BucketListController(BucketItemContext context)
        {
            _context = context;
        }

        // GET: api/BucketList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BucketItem>>> GetBucketItems()
        {
          if (_context.BucketItems == null)
          {
              return NotFound();
          }
            return await _context.BucketItems.ToListAsync();
        }

        // GET: api/BucketList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BucketItem>> GetBucketItem(long id)
        {
          if (_context.BucketItems == null)
          {
              return NotFound();
          }
            var bucketItem = await _context.BucketItems.FindAsync(id);

            if (bucketItem == null)
            {
                return NotFound();
            }

            return bucketItem;
        }

        // PUT: api/BucketList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBucketItem(long id, BucketItem bucketItem)
        {
            if (id != bucketItem.bucketId)
            {
                return BadRequest();
            }

            _context.Entry(bucketItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BucketItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BucketList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BucketItem>> PostBucketItem(BucketItem bucketItem)
        {
          if (_context.BucketItems == null)
          {
              return Problem("Entity set 'BucketItemContext.BucketItems'  is null.");
          }
            _context.BucketItems.Add(bucketItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBucketItem", new { id = bucketItem.bucketId }, bucketItem);
        }

        // DELETE: api/BucketList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBucketItem(long id)
        {
            if (_context.BucketItems == null)
            {
                return NotFound();
            }
            var bucketItem = await _context.BucketItems.FindAsync(id);
            if (bucketItem == null)
            {
                return NotFound();
            }

            _context.BucketItems.Remove(bucketItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BucketItemExists(long id)
        {
            return (_context.BucketItems?.Any(e => e.bucketId == id)).GetValueOrDefault();
        }
    }
}
