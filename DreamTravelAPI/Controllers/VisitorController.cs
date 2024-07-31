using DreamTravelAPI.DAL.Context;
using DreamTravelAPI.DAL.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravelAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Visitors.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult VisitorDetail(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
        [HttpPut]
        public IActionResult VisitorUpdate(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(visitor.VisitorID);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.Name = visitor.Name;
                    values.Surname = visitor.Surname;
                    values.City = visitor.City;
                    values.Country = visitor.Country;
                    values.Mail = visitor.Mail;

                    context.Update(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}