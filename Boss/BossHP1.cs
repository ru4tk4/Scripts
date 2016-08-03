using UnityEngine;
using System.Collections;
namespace Boss
{
    public class BossHP1 : MonoBehaviour
    {
        public BossHP hp;
        public EffectOpen effopen;
        public void BossChange()
        {
            hp.BossChange();
        }

        public void EO(int o)
        {
            effopen.EffectOpenEvent(o);
        }
    }
}
