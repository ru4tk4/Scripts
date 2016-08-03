using UnityEngine;
using System.Collections;

public class HHOOOOO : MonoBehaviour
{
    public Vector3 A;
    public Vector3 B;
    public Vector3 C;
    public GameObject D;
    void Update()
    {
        B = gameObject.transform.position;
        C = D.transform.position;
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.forward, Color.red);
        Debug.DrawRay(gameObject.transform.position, A, Color.green);
        Debug.DrawRay(gameObject.transform.position, C-B, Color.blue);
        
    }
}