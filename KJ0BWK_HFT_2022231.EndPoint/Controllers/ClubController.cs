using KJ0BWK_HFT_2022231.Logic;
using KJ0BWK_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KJ0BWK_HFT_2022231.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        IClubLogic logic;

        public ClubController(IClubLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Club> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<ClubController>/5
        [HttpGet("{id}")]
        public Club Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<ClubController>
        [HttpPost]
        public void Create([FromBody] Club value)
        {
            this.logic.Create(value);
        }

        // PUT api/<ClubController>/5
        [HttpPut]
        public void Update([FromBody] Club value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<ClubController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
