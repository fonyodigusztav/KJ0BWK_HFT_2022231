using KJ0BWK_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KJ0BWK_WpfClient
{
    public class MainWindowViewModel :ObservableRecipient
    {
        public RestCollection<Player> Players { get; set; }
        private Player selectedPlayer;

        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set 
            { 
                SetProperty(ref selectedPlayer, value);
                (DeletePlayerCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreatePlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        public ICommand UpdatePlayerCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Players = new RestCollection<Player>("http://localhost:64355/", "player");
                CreatePlayerCommand = new RelayCommand(() =>
                {
                    Players.Add(new Player()
                    {
                        Name = "DavidLuiz",
                        Age = 18
                    });
                });

                DeletePlayerCommand = new RelayCommand(() =>
                {
                    Players.Delete(SelectedPlayer.PlayerID);
                },
                () =>
                {
                    return SelectedPlayer != null;
                });
            }
            
        }
    }
}
