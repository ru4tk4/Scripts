using UnityEngine;
using System.Collections;
namespace Boss
{
    public class SiteDamage : MonoBehaviour
    {

        public BasicBoss self;
        public float ratio = 1;
        public int Increase = 0;
        public GameObject effect;
       
        // Use this for initialization
        void Start()
        {

        }

        public virtual void beDamaged(JSONObject json)
        {
            if (self)
            {
                int demage = (int)json.GetField("demage").n;
                json.SetField("demage", (demage * ratio) + Increase);
                self.beDamaged(json);
                if (effect)
                {
                    GameObject b1 = Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                    b1.transform.LookAt(self.target);
                }
            }
        }

    }
}
