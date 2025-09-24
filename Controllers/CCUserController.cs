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
    public class CCUserController : ControllerBase
    {
        private readonly CCDBContext _context;

        public CCUserController(CCDBContext context)
        {
            _context = context;
        }

        // GET: api/CCUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CCUserModel>>> GetTEMP_TEST_CCUserList()
        {
            if (_context.TEMP_TEST_CCUserList == null)
            {
                return NotFound();
            }
            return await _context.TEMP_TEST_CCUserList.ToListAsync();
        }

        // GET: api/CCUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CCUserModel>> GetCCUserModel(int id)
        {
            if (_context.TEMP_TEST_CCUserList == null)
            {
                return NotFound();
            }
            var cCUserModel = await _context.TEMP_TEST_CCUserList.FindAsync(id);

            if (cCUserModel == null)
            {
                return NotFound();
            }

            return cCUserModel;
        }

        // PUT: api/CCUser/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCCUserModel(int id, CCUserModel cCUserModel)
        {
            if (id != cCUserModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(cCUserModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CCUserModelExists(id))
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

        // POST: api/CCUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CCUserModel>> PostCCUserModel(CCUserModel cCUserModel)
        {
            if (_context.TEMP_TEST_CCUserList == null)
            {
                return Problem("Entity set 'CCDBContext.TEMP_TEST_CCUserList'  is null.");
            }
            _context.TEMP_TEST_CCUserList.Add(cCUserModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCCUserModel", new { id = cCUserModel.Id }, cCUserModel);
        }

        // DELETE: api/CCUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCCUserModel(int id)
        {
            if (_context.TEMP_TEST_CCUserList == null)
            {
                return NotFound();
            }
            var cCUserModel = await _context.TEMP_TEST_CCUserList.FindAsync(id);
            if (cCUserModel == null)
            {
                return NotFound();
            }

            _context.TEMP_TEST_CCUserList.Remove(cCUserModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CCUserModelExists(int id)
        {
            return (_context.TEMP_TEST_CCUserList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
