using Amazon.ElasticBeanstalk.Model;
using Amazon.IdentityManagement.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication4.dAL;
using WebApplication4.DTO;
using WebApplication4.Model;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : Controller
    {
        private AppDbConetxt _context { get; }

        public HumanController(AppDbConetxt conetxt)
        {
            _context = conetxt;
        }
        [Route("")]
        public IActionResult All()
        {
            List<Human> humen = _context.humans.ToList();
            return Ok(humen);
        }
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Human human = _context.humans.Find(id);
            if (human != null)
            {
                human.IsDelete = true;

            }
            _context.SaveChanges();


            return NoContent();
        }
        [HttpPost]


        public IActionResult Create(HumanDto hm1)
        {

            Human hm2 = new Human()
            {
                Name = hm1.Name,
                Image = hm1.Image,
                IsDelete = false,
                CreateDate = DateTime.Now
            };

            if (hm2 is null)
            {

                return StatusCode(400);
            }

            bool Musi = _context.humans.Any(a => a.Name.Trim().ToLower() == hm2.Name.ToLower().Trim());
            if (Musi)
            {
                return StatusCode(404);


            }
            _context.humans.Add(hm2);

            _context.SaveChanges();
            return NoContent();

        }
        [HttpPut, Route("{id}")]


        public IActionResult Update(int id, HumanDto hm1)
        {

            Human hm2 = _context.humans.Find(id);

            if (hm2 != null)
            {

                hm2.Name = hm1.Name;
                hm2.Image = hm1.Image;
                hm2.IsDelete = false;
            }
            _context.SaveChanges();

            return NoContent();

        }

    }
}
