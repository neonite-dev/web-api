using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workspace.Models;

namespace workspace.Controllers
{
    [Route("api/[controller]")]
    // Program.cs에서 AddCors -> AddPolicy = "VueAppPolicy"
    [EnableCors("VueAppPolicy")]
    [ApiController]
    //여기서 입력되는 컨트롤러 클래스 명이 곧 API 전송 URL이 된다.
    public class CCBoardController : ControllerBase
    {
        private readonly CCDBContext _context;

        public CCBoardController(CCDBContext context)
        {
            _context = context;
        }

        // GET: api/CCBoard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CCBoardModel>>> GetTEMP_TEST_CCBoardList()
        {
            if (_context.TEMP_TEST_CCBoardList == null)
            {
                return NotFound();
            }
            return await _context.TEMP_TEST_CCBoardList.ToListAsync();
        }

        // GET: api/CCBoard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CCBoardModel>> GetCCBoardModel(int id)
        {
            if (_context.TEMP_TEST_CCBoardList == null)
            {
                return NotFound();
            }
            var cCBoardModel = await _context.TEMP_TEST_CCBoardList.FindAsync(id);

            if (cCBoardModel == null)
            {
                return NotFound();
            }

            return cCBoardModel;
        }

        // PUT: api/CCBoard/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCCBoardModel(int id, CCBoardModel cCBoardModel)
        {
            if (id != cCBoardModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(cCBoardModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CCBoardModelExists(id))
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

        // POST: api/CCBoard
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CCBoardModel>> PostCCBoardModel(CCBoardModel cCBoardModel)
        {
            if (_context.TEMP_TEST_CCBoardList == null)
            {
                return Problem("Entity set 'CCDBContext.TEMP_TEST_CCBoardList'  is null.");
            }
            _context.TEMP_TEST_CCBoardList.Add(cCBoardModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCCBoardModel", new { id = cCBoardModel.Id }, cCBoardModel);
        }

        // DELETE: api/CCBoard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCCBoardModel(int id)
        {
            if (_context.TEMP_TEST_CCBoardList == null)
            {
                return NotFound();
            }
            var cCBoardModel = await _context.TEMP_TEST_CCBoardList.FindAsync(id);
            if (cCBoardModel == null)
            {
                return NotFound();
            }

            _context.TEMP_TEST_CCBoardList.Remove(cCBoardModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CCBoardModelExists(int id)
        {
            return (_context.TEMP_TEST_CCBoardList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
