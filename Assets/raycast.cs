using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class raycast : MonoBehaviour {

	public Camera cam;
	public RaycastHit hit;
	public RaycastHit lastHit;
	public Material normalMaterial;
	public Material outlineMaterial;


	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>().GetComponent<Camera>();
		outlineMaterial = Resources.Load("New Material") as Material;
		normalMaterial = Resources.Load ("StandardMaterial") as Material;
		lastHit = new RaycastHit ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		Ray fwd = new Ray (transform.position, transform.forward);
		if (Physics.Raycast (ray, out hit)) {
			if (!lastHit.Equals(hit)) {
				lastHit.collider.gameObject.GetComponent<MeshRenderer> ().material = normalMaterial;
				lastHit = hit;
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material = outlineMaterial;
			} else {
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material = outlineMaterial;
			}
		} else {
			lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
		}
			

		Debug.DrawRay (transform.position, transform.forward, Color.yellow, 999, false);
	}
}
