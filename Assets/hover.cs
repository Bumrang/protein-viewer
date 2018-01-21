using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MeshFilter[] meshes = gameObject.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter child in meshes)
		{
			child.gameObject.AddComponent(typeof(MeshCollider));
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
