﻿using UnityEngine;
using System.Collections;

public class MyClass : MonoBehaviour
{
	void Start ()
	{
		MeshFilter [] meshFilters = GetComponentsInChildren<MeshFilter> ();
		CombineInstance[] combine = new CombineInstance[meshFilters.Length];
		
		for (int i = 0; i < meshFilters.Length; i++) {
			combine [i].mesh = meshFilters [i].sharedMesh;
			combine [i].transform = meshFilters [i].transform.localToWorldMatrix;
			meshFilters [i].gameObject.active = false; 
		}
		
		transform.GetComponent<MeshFilter> ().mesh = new Mesh ();
		transform.GetComponent<MeshFilter> ().mesh.CombineMeshes (combine);
		transform.gameObject.active = true;
	}
}