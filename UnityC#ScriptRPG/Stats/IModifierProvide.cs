using System.Collections.Generic;

namespace RPG.Stats
{
    public interface IModifierProvide
    {
        IEnumerable<float> GetAdditiveModifier(Stat stat); //able ��twiej w petlach umieszcza�
        IEnumerable<float> GetProcentageModifire(Stat stat);
    }
}
