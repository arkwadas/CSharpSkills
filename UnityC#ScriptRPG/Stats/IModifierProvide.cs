using System.Collections.Generic;

namespace RPG.Stats
{
    public interface IModifierProvide
    {
        IEnumerable<float> GetAdditiveModifier(Stat stat); //able ³¹twiej w petlach umieszczaæ
        IEnumerable<float> GetProcentageModifire(Stat stat);
    }
}
