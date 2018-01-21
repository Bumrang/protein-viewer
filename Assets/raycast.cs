using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class raycast : MonoBehaviour {

	Camera cam;
	RaycastHit hit;
	RaycastHit lastHit;
	Shader outlineMaterial = Shader.Find ("Outlined/Silhouetted Diffuse");
	Shader normalMaterial = Shader.Find ("Standard");


	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>().GetComponent<Camera>();
		Debug.Log (cam.name);
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		Ray fwd = new Ray (transform.position, transform.forward);
		if (Physics.Raycast (ray, out hit)) {
			Debug.Log (hit.collider.gameObject.GetComponent<MeshRenderer>().material.shader.name);
			lastHit = hit;
			hit.collider.gameObject.GetComponent<MeshRenderer>().material.shader = outlineMaterial;
		} else {
			lastHit.collider.gameObject.GetComponent<MeshRenderer>().material.shader = normalMaterial;
		}
			

		Debug.DrawRay (transform.position, transform.forward, Color.yellow, 999, false);
	}
}
