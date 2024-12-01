using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace IntersectionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class FindIntersectionController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PointF> FindIntersection(Intersection request)
        {
            float denominator = (request.X1 - request.X2) * (request.Y3 - request.Y4) - (request.Y1 - request.Y2) * (request.X3 - request.X4);
            if (denominator == 0)
            {
                return BadRequest("Прямі паралельні або співпадають.");
            }

            float px = ((request.X1 * request.Y2 - request.Y1 * request.X2) * (request.X3 - request.X4) - (request.X1 - request.X2) * (request.X3 * request.Y4 - request.Y3 * request.X4)) / denominator;
            float py = ((request.X1 * request.Y2 - request.Y1 * request.X2) * (request.Y3 - request.Y4) - (request.Y1 - request.Y2) * (request.X3 * request.Y4 - request.Y3 * request.X4)) / denominator;

            return Ok(new PointF(px, py));
        }

        [HttpGet]
        public IActionResult GetIntersection()
        {
            return Ok("Intersection Service is running.");
        }
    }
}
