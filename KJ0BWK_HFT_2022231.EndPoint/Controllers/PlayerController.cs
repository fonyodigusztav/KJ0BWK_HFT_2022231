using KJ0BWK_HFT_2022231.EndPoint.Services;
using KJ0BWK_HFT_2022231.Logic;
using KJ0BWK_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;


namespace KJ0BWK_HFT_2022231.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        IPlayerLogic logic;
        IHubContext<SignalRHub> hub;
        public PlayerController(IPlayerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Player> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Player Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Player value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("PlayerCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Player value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("PlayerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var actorToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("PlayerDeleted", actorToDelete);
        }
    }
}
