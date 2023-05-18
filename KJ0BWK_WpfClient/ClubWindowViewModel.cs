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
    public class ClubWindowViewModel : ObservableRecipient
    {
        public RestCollection<Club> Clubs { get; set; }
        private Club selectedClub;

        public Club SelectedClub
        {
            get { return selectedClub; }
            set
            {
                if (value != null)
                {
                    selectedClub = new Club()
                    {
                        Name = value.Name,
                        ClubID = value.ClubID,
                        Championship = value.Championship,
                        Owner = value.Owner,
                        OwnerID = value.OwnerID
                    };
                    OnPropertyChanged();
                    (DeleteClubCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateClubCommand { get; set; }
        public ICommand DeleteClubCommand { get; set; }
        public ICommand UpdateClubCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ClubWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Clubs = new RestCollection<Club>("http://localhost:64355/", "club");
                CreateClubCommand = new RelayCommand(() =>
                {
                    Clubs.Add(new Club()
                    {
                        Name = SelectedClub.Name,
                        Championship = SelectedClub.Championship,
                        Owner = SelectedClub.Owner,
                        OwnerID = SelectedClub.OwnerID
                    });
                });

                UpdateClubCommand = new RelayCommand(() =>
                {
                    Clubs.Update(SelectedClub);
                });

                DeleteClubCommand = new RelayCommand(() =>
                {
                    Clubs.Delete(SelectedClub.ClubID);
                },
                () =>
                {
                    return SelectedClub != null;
                });
                SelectedClub = new Club();
            }

        }
    }
}
