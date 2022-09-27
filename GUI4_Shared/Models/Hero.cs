using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI4_Shared.Models
{

    public class Hero : ObservableObject
    {
        public enum type{ jó, gonosz, semleges}
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int power;
        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }

        private int speed;
        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        public Hero GetCopy()
        {
            return new Hero()
            {
                Name = this.Name,
                Power = this.Power,
                Speed = this.Speed
            };
        }
    }
}
