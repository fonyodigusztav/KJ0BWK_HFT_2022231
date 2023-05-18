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
    public class OwnerWindowViewModel : ObservableRecipient
    {
        public RestCollection<Owner> Owners { get; set; }
        private Owner selectedOwner;

        public Owner SelectedOwner
        {
            get { return selectedOwner; }
            set
            {
                if (value != null)
                {
                    selectedOwner = new Owner()
                    {
                        Name = value.Name,
                        Age = value.Age,
                        OwnerID = value.OwnerID,
                        Clubs = value.Clubs
                    };
                    OnPropertyChanged();
                    (DeleteOwnerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateOwnerCommand { get; set; }
        public ICommand DeleteOwnerCommand { get; set; }
        public ICommand UpdateOwnerCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public OwnerWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Owners = new RestCollection<Owner>("http://localhost:64355/", "owner");
                CreateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Add(new Owner()
                    {
                        Name = SelectedOwner.Name,
                        Age = SelectedOwner.Age,
                    });
                });

                UpdateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Update(SelectedOwner);
                });

                DeleteOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Delete(SelectedOwner.OwnerID);
                },
                () =>
                {
                    return SelectedOwner != null;
                });
                SelectedOwner = new Owner();
            }

        }
    }
}
