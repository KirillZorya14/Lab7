using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RenderGraphService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class RenderGraphController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> RenderGraph(Graph request)
        {
            var svg = $@"
        <svg width='500' height='500' xmlns='http://www.w3.org/2000/svg'>
            <line x1='{request.X1 * 50}' y1='{request.Y1 * 50}' x2='{request.X2 * 50}' y2='{request.Y2 * 50}' stroke='blue' />
            <line x1='{request.X3 * 50}' y1='{request.Y3 * 50}' x2='{request.X4 * 50}' y2='{request.Y4 * 50}' stroke='red' />
            <circle cx='{request.Px * 50}' cy='{request.Py * 50}' r='5' fill='green' />
        </svg>";
            return Ok(svg);
        }

        [HttpGet]
        public IActionResult GetGraph()
        {
            return Ok("Graph Service is running.");
        }
    }
}
