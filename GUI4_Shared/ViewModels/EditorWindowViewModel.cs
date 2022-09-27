using GUI4_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI4_Shared.ViewModels
{
    public class EditorWindowViewModel
    {
        public Hero Actual { get; set; }

        public void Setup(Hero hero)
        {
            this.Actual = hero;
        }
        public EditorWindowViewModel()
        {

        }
    }
}
