using UnityEngine;
using System.Collections;
namespace Boss
{
    public class SiteDamage1 : MonoBehaviour
    {

        public BasicBoss self;
        public float ratio = 1;
        public int Increase = 0;
        public GameObject effect;
		public SkinnedMeshRenderer monder;
        // Use this for initialization
        void Start()
        {

        }

		int K = 0;

		public void renderbake()
		{
			K++;
			StartCoroutine(RenderTime(0.05f,K));
		}
		IEnumerator RenderTime(float waitTime ,int i)
		{
			yield return new WaitForSeconds(waitTime);

			//selfRender.monder.material.SetFloat("_Outline", 0f);
			if (i==K)
			{
				if(monder)
					monder.material.SetColor("_TintColor",Color.black );
				//selfRender.monder.material.SetFloat("_Outline", 0f);
				K = 0;                
			}
		}

        public virtual void beDamaged(JSONObject json)
        {
            if (self)
            {
                int demage = (int)json.GetField("demage").n;
                json.SetField("demage", (demage * ratio) + Increase);
                self.beDamaged(json);
				if (monder) {
					monder.material.SetColor ("_TintColor", new Color (1, 1, 1, 1));
					renderbake(); 
				}
                if (effect)
                {
                    GameObject b1 = Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                    b1.transform.LookAt(self.target);
                }
            }
        }

    }
}
