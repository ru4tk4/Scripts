using UnityEngine;
using System.Collections;

namespace Boss
{
    public class FreeType : BasicBoss
    {
        public string Name;
        
        int canEndureDemage = 200;
        void Start()
        {
            //Defualt Search
            base.Start();
            getBossData(Name);
            currentState = gameObject.AddComponent<IdleSkill>();
            currentState.enter(this);

        }

        protected void FixedUpdate()
        {
            m_Ani.SetFloat("DD", TargetData().w);
            if (state != BasicBoss.BossState.Dead)
            {
                //currentState.execute();
                base.FixedUpdate();
            }
        }

        public override void beDamaged(JSONObject json)
        {
            if (state != BossState.Dead)
            {

                base.beDamaged(json);
                damagebehavior.golemEffect(json.GetField("demage").n, canEndureDemage);
            }
        }


    }
}