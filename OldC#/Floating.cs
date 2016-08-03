using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {
	public float radian = 0; // 弧度
	public float perRadian = 0.03f; // 每次变化的弧度
	public float radius;
	public float radiusMAX;
	public bool Off;
    public float WaitTime;
     // 半径
    Vector3 oldPos; // 开始时候的坐标
	// Use this for initialization
	void Start () {
		oldPos = transform.position; // 将最初的位置保存到oldPos        
        StartCoroutine(Time1(WaitTime));
        //gameObject.GetComponent<Rigidbody> ().AddForce ((gameObject.transform.forward + new Vector3 (0, 1, 0)) * Speed);
    }

    IEnumerator Time1(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Off = true;
    }

    // Update is called once per frame
    void Update () {
		if (Off == false) {
			radian += perRadian;// 弧度每次加0.03
			//perRadian = Random.Range (0.01, 0.03);

			float yradius = Random.Range (radius, radiusMAX);


			float dy = Mathf.Cos (radian) * radiusMAX;// dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以
			transform.position = oldPos + new Vector3 (0, dy, 0);
		}
	}
}
