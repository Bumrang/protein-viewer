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
	public bool firstHit;


	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>().GetComponent<Camera>();
		outlineMaterial = Resources.Load("New Material") as Material;
		normalMaterial = Resources.Load ("StandardMaterial") as Material;
		Physics.Raycast (cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0)), out lastHit);
		firstHit = true;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		Ray fwd = new Ray (transform.position, transform.forward);
		if (Physics.Raycast (ray, out hit)){
			if (firstHit){
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material = outlineMaterial;
				lastHit = hit;
				firstHit = false;
			} 
			else if (!lastHit.collider.name.Equals (hit.collider.name)) {
				Debug.Log (lastHit.collider.name);
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material = outlineMaterial;
				lastHit.collider.gameObject.GetComponent<MeshRenderer> ().material = normalMaterial;
				lastHit = hit;
			} 
			else{
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material = outlineMaterial;
//				lastHit.collider.gameObject.GetComponent<MeshRenderer> ().material = normalMaterial;
			}
		} 
		else 
			lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
		
	}
}
