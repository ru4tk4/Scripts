using UnityEngine;
using System.Collections;

public class WanpenLocking2 : MonoBehaviour {
    public Transform target;
    public float viewAngle = 20.0f; // 尋敵角度
    public float viewDis = 8.0f;  // 尋敵距離

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
         float dis = Vector3.Distance(transform.position, target.transform.position);
        if (dis < viewDis)
        {
            // 宣告 注視目標座標 為 目標位置
            Vector3 lookAtPos  = target.position;
            // 本身與目標之間相對位置
            Vector3 relative  = transform.InverseTransformPoint(lookAtPos);
            // 計算兩者之間角度
            float angle  = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            // 兩者角度絕對值 小於 尋迪角度 則
            if (Mathf.Abs(angle) < viewAngle)
            {
                // 注視目標座標Y軸 為 自身Y軸
                lookAtPos.y = transform.position.y;
                // 注視目標
                transform.LookAt(lookAtPos);
            }
        }

    }
}
