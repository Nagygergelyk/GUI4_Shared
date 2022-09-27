using GUI4_Shared.Logic;
using GUI4_Shared.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI4_Shared.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IHeroLogic logic;

        public ObservableCollection<Hero> Barrack { get; set; }
        public ObservableCollection<Hero> Army { get; set; }

        private Hero selectedFromBarracks;

        public Hero SelectedFromBarracks
        {
            get { return selectedFromBarracks; }
            set
            {
                SetProperty(ref selectedFromBarracks, value);
                (SendToWarCommand as RelayCommand).NotifyCanExecuteChanged();
                (CreateSuperheroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private Hero selectedFromArmy;

        public Hero SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set
            {
                SetProperty(ref selectedFromArmy, value);
                (SendHomeCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand SendToWarCommand { get; set; }
        public ICommand SendHomeCommand { get; set; }
        public ICommand CreateSuperheroCommand { get; set; }
        public MainWindowViewModel()
        {

        }

        public double AVGPower
        {
            get
            {
                return logic.AVGPower;
            }
        }

        public double AVGSpeed
        {
            get
            {
                return logic.AVGSpeed;
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel(IHeroLogic logic)
        {
            this.logic = logic;
            Barrack = new ObservableCollection<Hero>();
            Army = new ObservableCollection<Hero>();

            Barrack.Add(new Hero()
            {
                Name = "marine",
                Power = 8,
                Speed = 6
            });
            Barrack.Add(new Hero()
            {
                Name = "pilot",
                Power = 7,
                Speed = 3
            });
            Barrack.Add(new Hero()
            {
                Name = "infantry",
                Power = 6,
                Speed = 8
            });
            Barrack.Add(new Hero()
            {
                Name = "sniper",
                Power = 3,
                Speed = 3
            });
            Barrack.Add(new Hero()
            {
                Name = "engineer",
                Power = 5,
                Speed = 6
            });

            Army.Add(Barrack[2].GetCopy());
            Army.Add(Barrack[4].GetCopy());

            logic.SetupCollections(Barrack, Army);

            SendToWarCommand = new RelayCommand(
                () => logic.SendToWar(SelectedFromBarracks),
                () => SelectedFromBarracks != null
                );

            SendHomeCommand = new RelayCommand(
                () => logic.SendHome(SelectedFromArmy),
                () => SelectedFromArmy != null
                );

            CreateSuperheroCommand = new RelayCommand(
                () => logic.CreateSuperhero(SelectedFromBarracks),
                () => SelectedFromBarracks != null
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
            });
        }
    }
}
