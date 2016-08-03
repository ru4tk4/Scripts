using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerEnergy: MonoBehaviour {

    public Player player;
    public float Reduce;
    public float restore;
    public float Armor;
    public float foot;
    public float weapon;
    public float robot;
    public float tortor;
    public Text W;
    public Text A;
    public Text F;
    // Use this for initialization
    void Start () {
        if (GetComponent<Player>())
        {
            player = GetComponent<Player>();
        }
        InvokeRepeating("EnergyUpdate", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U))
            Armor += 5f;
        if (Input.GetKeyDown(KeyCode.Y))
            Armor -= 5f;
        if (Input.GetKeyDown(KeyCode.J))
            foot += 5f;
        if (Input.GetKeyDown(KeyCode.H))
            foot -= 5f;
        if (Input.GetKeyDown(KeyCode.M))
            weapon += 5f;
        if (Input.GetKeyDown(KeyCode.N))
            weapon -= 5f;
        W.text = "武器" + weapon;
        A.text = "裝甲" + Armor;
        F.text = "動力" + foot;
    }
    void EnergyUpdate()
    {
        tortor = Armor + foot + weapon;
        player.ES_AtkRatio = 1 + weapon * 0.02f;
        player.ES_bulletRato = 1 + weapon * 0.02f;
        player.AniSpeed = 1 + foot * 0.02f;
        player.maxHP = 100 + Armor*12.3f;
        player.HPs = 3 + Armor * 0.9f;
        if (player.energy > 0)
        {
            player.energy -= g(tortor);
        }
        else
        {
            Armor = 0;
            weapon = 0;
            foot = 0;
        }
        if (player.hp < player.maxHP)
        {
            player.hp += player.HPs;
            player.energy-= player.HPs;
        }
        player.energy += restore;
    }
    public float g (float x ){
        float re;
        x = x / 10;
        re = Reduce * x + x*0.2f;
        return re;
        }
}
