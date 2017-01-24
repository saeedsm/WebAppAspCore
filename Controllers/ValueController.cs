using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetGroupTalk.Controllers
{
    [Route("api/[controller]")]
    public class ValueController :Controller{
        
        [HttpGetAttribute()]
        public async Task<IActionResult> Values(){
            return await Task.FromResult(new JsonResult(new {Name = "hello"}));
        }
    }
}