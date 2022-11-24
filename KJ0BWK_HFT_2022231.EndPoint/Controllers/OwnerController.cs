using KJ0BWK_HFT_2022231.Logic;
using KJ0BWK_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace KJ0BWK_HFT_2022231.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        IOwnerLogic logic;

        public OwnerController(IOwnerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Owner> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Owner Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Owner value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Owner value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
