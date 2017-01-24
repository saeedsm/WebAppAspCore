using System.Linq;
using System.Threading.Tasks;
using DotNetGroupTalk.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetGroupTalk.Controllers
{
    [Route("api/[controller]")]
    public class ValueController :Controller{
        
        private ProductContext _context;
        public ValueController(ProductContext context)
        {
            _context = context;
        }

        [HttpGetAttribute()]
        public async Task<IActionResult> Values(){

            return await Task.FromResult(new JsonResult(_context.Products.ToList()));
        }
    }
}