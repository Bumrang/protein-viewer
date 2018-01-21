using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class raycast : MonoBehaviour {

	Camera cam;
	RaycastHit hit;
	RaycastHit lastHit;
	Material outlineMaterial = Resources.Load ("Outlined/Silhouetted Diffuse", typeof(Material)) as Material;
	Material normalMaterial = Resources.Load ("Standard", typeof(Material)) as Material;


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
			Debug.Log ("I hit " + hit.collider.gameObject.name);
			lastHit = hit;
			//hit.collider.attachedRigidbody.gameObject
		} else {
			lastHit.collider.material = normalMaterial;
		}
			

		Debug.DrawRay (transform.position, transform.forward, Color.yellow, 999, false);
	}
}
