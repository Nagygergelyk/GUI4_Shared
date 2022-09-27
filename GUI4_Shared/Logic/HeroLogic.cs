using GUI4_Shared.Models;
using GUI4_Shared.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI4_Shared.Logic
{
    public class HeroLogic : IHeroLogic
    {
        IList<Hero> barracks;
        IList<Hero> army;
        IMessenger messenger;
        IHeroEditorService editorService;
        public void SetupCollections(IList<Hero> barracks, IList<Hero> army)
        {
            this.barracks = barracks;
            this.army = army;
        }
        public HeroLogic(IMessenger messenger, IHeroEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }
        public double AVGPower
        {
            get
            {
                return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Power), 2);
            }
        }

        public double AVGSpeed
        {
            get
            {
                return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Speed), 2);
            }
        }
        public void CreateSuperhero(Hero hero)
        {
            editorService.Edit(hero);
        }

        public void SendHome(Hero hero)
        {
            army.Remove(hero);
            messenger.Send("Hero removed", "TrooperInfo");
        }

        public void SendToWar(Hero hero)
        {
            army.Add(hero.GetCopy());
            messenger.Send("Hero added", "TrooperInfo");
        }

      
    }
}
