using KJ0BWK_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Player> Players { get; set; }
        public MainWindowViewModel()
        {
            Players = new RestCollection<Player>("http://localhost:64355/", "player");
        }
    }
}
