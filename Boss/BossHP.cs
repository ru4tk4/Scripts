using UnityEngine;
using System.Collections;
namespace Boss
{
    public class BossHP : MonoBehaviour
    {
        BasicBoss self;
        Animator ani;
        EffectOpen efop;
        public EffectOpen efop2;
        public SkinnedMeshRenderer[] monders;
        public float smoothTime = 0.3F;
        private float yVelocity = 0.0F;
        float HP;
        public bool bosslight = false;
        Vector4 colork;
        public float a = 0;
        // Use this for initialization
        void Start()
        {
            self = gameObject.transform.parent.GetComponent<BasicBoss>();
            ani = gameObject.transform.parent.GetComponent<Animator>();
            efop = gameObject.transform.parent.GetComponent<EffectOpen>();
            colork = monders[0].material.GetColor("_TintColor");
            HP = self.hp;
        }
        bool aa;
        bool bb;
        // Update is called once per frame
        void Update()
        {
            ani.SetFloat("Hp", self.hp / HP);


            if (bosslight == true)

            {
                if (self == null)
                {
                    a = Mathf.SmoothDamp(a, 0.0f, ref yVelocity, smoothTime);
                    if(bb == false)
                    {
                        
                        transform.parent.GetComponent<BossHP1>().effopen = GetComponent<EffectOpen>();
                    }
                }
                else
                {
                    if (a <= 1 && aa == false)
                    {
                        a = Mathf.SmoothDamp(a, 1.1f, ref yVelocity, smoothTime);
                    }
                    else
                    {
                        aa = true;

                    }
                    if (a >= 0.1f && aa == true)
                    {
                        a = Mathf.SmoothDamp(a, 0.0f, ref yVelocity, smoothTime);
                    }
                    else
                    {
                        aa = false;
                    }
                }

                foreach (SkinnedMeshRenderer monder in monders)
                {
                    monder.material.SetColor("_TintColor", new Color(colork.x, colork.y, colork.z, a));
                }

            }
            
        }


        public void BossChange()
        {
            efop.Effects = efop2.Effects;
            bosslight = true;
            ani.SetBool("Two", true);
            self.hp = HP;

        }

    }
}
