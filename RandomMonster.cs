using UnityEngine;
using System.Collections;

public class RandomMonster : MonoBehaviour {

	public GameObject Obj;
	public GameObject[] Local;
	public int Obj_Amount;
    int number = 20;


	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Creat", 2, 2);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Enter")) 
		{
			Vector3 creat = new Vector3 (Random.Range (0,0 ), Random.Range (0, 0), Random.Range (0, 0));
			//Instantiate (Obj, creat, Quaternion.identity);
			//Instantiate (Obj, creat, Quaternion.identity);
		}
	}

	void Creat()
	{
        if (NewerUI.Gamepaused == false)
        {
            GameObject test = Instantiate(Obj, Local[Random.Range(0, 5)].transform.position, Local[Random.Range(0, 5)].transform.rotation) as GameObject;
        }
	}

    /*IEnumerator MonsteIe(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject test = Instantiate(Obj[number], Local.transform.position, Local.transform.rotation) as GameObject;
        number++;
    }*/
}
