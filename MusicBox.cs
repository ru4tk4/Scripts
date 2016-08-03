using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour
{
    public float number;
    private Player player;

    void Awake()
    {
        player.bgm.st();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.bgm.enemy.setValue(number);
        }
    }

    /*void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player.bgm.ambient.setValue(number);
        }
    }*/
}
