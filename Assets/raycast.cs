using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class raycast : MonoBehaviour {

	public Camera cam;
	public RaycastHit hit;
	public RaycastHit lastHit;
	public Material normalMaterial;
	public Material outlineMaterial;
    public UpdateAtomText newAtom;
	public bool firstHit;


	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>().GetComponent<Camera>();
		outlineMaterial = Resources.Load("New Material") as Material;
		normalMaterial = Resources.Load ("StandardMaterial") as Material;
		Physics.Raycast (cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0)), out lastHit);
		firstHit = true;
        newAtom = gameObject.GetComponent("UpdateAtomText") as UpdateAtomText;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		Ray fwd = new Ray (transform.position, transform.forward);
		if (Physics.Raycast (ray, out hit)) {
			if (firstHit) {
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material = outlineMaterial;
				lastHit = hit;
				firstHit = false;
			} else if (!lastHit.collider.name.Equals (hit.collider.name)) {
				Debug.Log (lastHit.collider.name);
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material = outlineMaterial;
				resetColor (lastHit);
				lastHit = hit;
			} else
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material = outlineMaterial;
		} else { 
			resetColor (lastHit);
		}
		
	}

	void resetColor(RaycastHit lastHit){
		if (lastHit.collider.gameObject.name.Contains ("Sulfur"))
        {
            lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Sulfur") as Material;
            newAtom.ChangeText("Sulfur");
        } else if (lastHit.collider.gameObject.name.Contains("Hydrogen"))
        {
            lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Hydrogen") as Material;
            newAtom.ChangeText("Hydrogen");
        } else if (lastHit.collider.gameObject.name.Contains("Mercury"))
        {
            lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Mercury") as Material;
            newAtom.ChangeText("Mercury");
        } else if (lastHit.collider.gameObject.name.Contains("Oxygen"))
        {
            lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Oxygen") as Material;
            newAtom.ChangeText("Oxygen");
        } else if (lastHit.collider.gameObject.name.Contains("Nitrogen"))
        {
            lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Nitrogen") as Material;
            newAtom.ChangeText("Nitrogen");
        } else if (lastHit.collider.gameObject.name.Contains("Carbon"))
        {
            lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Carbon") as Material;
            newAtom.ChangeText("Carbon");
        } else if (lastHit.collider.gameObject.name.Contains("Ball_HD"))
        {
            lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Ball_HD") as Material;
            newAtom.ChangeText("");


        }
			
	}
}
