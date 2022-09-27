using GUI4_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI4_Shared.Services
{
    class HeroEditorViaWindow : IHeroEditorService
    {
        public void Edit(Hero hero)
        {
            new EditorWindow(hero).ShowDialog();
        }
    }
}
