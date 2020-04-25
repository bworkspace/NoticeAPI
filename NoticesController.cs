using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticeBoardAPI.Data;
using NoticeBoardAPI.models;
using System.Data.Entity;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace NoticeBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticesController : ControllerBase
    {
        private readonly NoticeContext _context;

        public NoticesController(NoticeContext context)
        {
            _context = context;
        }

        // GET: api/Notices
        [HttpGet]
        public ActionResult<IEnumerable<Notice>> GetNotices()
        {
            var t = _context.Notices
                .Where(dt => dt.N_endDate > DateTime.Now && dt.N_startDate < DateTime.Now)
                .Select(n => new {
                n.N_message, n.N_postDate, n.N_startDate, n.N_endDate, n.Users.U_name })
                .ToList();

            return Ok(t);
        }

        // GET: api/Notices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notice>> GetNotice(int id)
        {
            var notice = await _context.Notices.ToListAsync();

            if (notice == null)
            {
                return NotFound();
            }

            return Ok(notice);
        }

        // PUT: api/Notices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotice(int id, Notice notice)
        {
            if (id != notice.N_id)
            {
                return BadRequest();
            }

            _context.Entry(notice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeExists(id))
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

        // POST: api/Notices
        [HttpPost]
        public async Task<ActionResult<Notice>> PostNotice(Notice notice)
        {
            _context.Notices.Add(notice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotice", new { id = notice.N_id }, notice);
        }

        // DELETE: api/Notices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notice>> DeleteNotice(int id)
        {
            var notice = await _context.Notices.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }

            _context.Notices.Remove(notice);
            await _context.SaveChangesAsync();

            return notice;
        }

        private bool NoticeExists(int id)
        {
            return _context.Notices.Any(e => e.N_id == id);
        }
    }
}
