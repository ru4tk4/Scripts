using UnityEngine;
using System.Collections;

public class WeaponMazUI : MonoBehaviour
{
    public GameObject Target;
    public Camera PlayerCamera;

    void Update()
    {
        gameObject.transform.position = PlayerCamera.WorldToScreenPoint(Target.transform.position);
    }
}
