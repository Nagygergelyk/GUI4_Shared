using GUI4_Shared.Models;
using System.Collections.Generic;

namespace GUI4_Shared.Logic
{
    public interface IHeroLogic
    {
        double AVGPower { get; }
        double AVGSpeed { get; }

        void SendToWar(Hero hero);
        void CreateSuperhero(Hero hero);
        void SendHome(Hero hero);
        void SetupCollections(IList<Hero> barracks, IList<Hero> army);
    }
}