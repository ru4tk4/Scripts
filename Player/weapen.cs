using UnityEngine;
using System.Collections;

public class weapen : MonoBehaviour {

    public string name;
    public float Gunlost;//子彈消耗
    public float bulletdem = 5; //子彈威力
 
    public float ShootRange = 10; //射程
    public float BulletSpeed = 100; //彈速
    public float fire_CD = 1; //射擊間隔
    public float Magazine = 10; //彈夾量
    public float reloadTime = 2; //裝填時間
    public float AtkRise = 0f; //攻擊上升量
    
    public float Stable;
    public GameObject Bullet; // 子彈特效
    public GameObject Bullet_fire; //槍管特效
    public GameObject Reload_effect; //填充特效
    public GameObject Reload_here; //填充特效位置
    public GameObject Fire_here; //槍口
    public GameObject FireUI;
    public Animator RealoadUI;
    public GameObject MazUI;

    public int Magazine_Save; //紀錄子彈

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
