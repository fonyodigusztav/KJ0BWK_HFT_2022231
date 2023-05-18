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
    public class PlayerWindowViewModel : ObservableRecipient
    {
        public RestCollection<Player> Players { get; set; }
        private Player selectedPlayer;

        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (value != null)
                {
                    selectedPlayer = new Player()
                    {
                        Name = value.Name,
                        Age = value.Age,
                        Club = value.Club,
                        ClubID = value.ClubID,
                        PlayerID = value.PlayerID,
                        Position = value.Position,
                        Rating = value.Rating
                    };
                    OnPropertyChanged();
                    (DeletePlayerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
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
        public PlayerWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Players = new RestCollection<Player>("http://localhost:64355/", "player", "hub");
                CreatePlayerCommand = new RelayCommand(() =>
                {
                    Players.Add(new Player()
                    {
                        Name = SelectedPlayer.Name,
                        Age = SelectedPlayer.Age,
                        Club = SelectedPlayer.Club,
                        Position = SelectedPlayer.Position,
                        ClubID = SelectedPlayer.ClubID,
                        //PlayerID = Players.Last().PlayerID + 1,
                        Rating = SelectedPlayer.Rating
                    });
                });

                UpdatePlayerCommand = new RelayCommand(() =>
                {
                    Players.Update(SelectedPlayer);
                });

                DeletePlayerCommand = new RelayCommand(() =>
                {
                    Players.Delete(SelectedPlayer.PlayerID);
                },
                () =>
                {
                    return SelectedPlayer != null;
                });
                SelectedPlayer = new Player();
            }

        }
    }
}
