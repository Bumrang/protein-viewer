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
	public Material sulfur, hydrogen, mercury, oxygen, nitrogen, carbon, ballhd;
    public UpdateAtomText newAtom;
	public bool firstHit;
    public bool reset;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>().GetComponent<Camera>();
		outlineMaterial = Resources.Load("New Material") as Material;
		normalMaterial = Resources.Load ("StandardMaterial") as Material;
		sulfur = Resources.Load("Sulfur") as Material;;
		hydrogen = Resources.Load("Hydrogen") as Material;;
		mercury = Resources.Load("Mercury") as Material;;
		oxygen = Resources.Load("Oxygen") as Material;;
		nitrogen = Resources.Load("Nitrogen") as Material;;
		carbon = Resources.Load("Carbon") as Material;;
		ballhd = Resources.Load("Ball_HD") as Material;;
		Physics.Raycast (cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0)), out lastHit);
		firstHit = true;
        newAtom = gameObject.GetComponent("UpdateAtomText") as UpdateAtomText;
        reset = false;

	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = cam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		Ray fwd = new Ray (transform.position, transform.forward);
		if (Physics.Raycast (ray, out hit)) {
			Debug.Log (hit.collider.name);
            if (firstHit)
            { 
                hit.collider.gameObject.GetComponent<MeshRenderer>().material = outlineMaterial;
                lastHit = hit;
                firstHit = false;
                reset = true;
            }
            else if (!lastHit.collider.name.Equals(hit.collider.name))
            {
                Debug.Log(lastHit.collider.name);
                hit.collider.gameObject.GetComponent<MeshRenderer>().material = outlineMaterial;
				//lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
                resetColor(lastHit);
                lastHit = hit;
            }
            else
                reset = true;
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material = outlineMaterial;
		} else { 
			resetColor (lastHit);
			//lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
		}
		
	}

	void resetColor(RaycastHit lastHit){
        if (!reset) { return; }
		if (lastHit.collider.name.Contains ("Sulfur"))
        {
			lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = sulfur;
           // newAtom.ChangeText("Sulfur");
        } else if (lastHit.collider.name.Contains("Hydrogen"))
        {
			lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = hydrogen;
          //  newAtom.ChangeText("Hydrogen");
        } else if (lastHit.collider.name.Contains("Mercury"))
        {
			lastHit.collider.gameObject.GetComponent<MeshRenderer> ().material = mercury;
           // newAtom.ChangeText("Mercury");
        } else if (lastHit.collider.name.Contains("Oxygen"))
        {
			lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = oxygen;
           // newAtom.ChangeText("Oxygen");
        } else if (lastHit.collider.name.Contains("Nitrogen"))
        {
			lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = nitrogen;
           // newAtom.ChangeText("Nitrogen");
        } else if (lastHit.collider.name.Contains("Carbon"))
        {
			lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = carbon;
            //newAtom.ChangeText("Carbon");
        } else if (lastHit.collider.name.Contains("Ball_HD"))
        {
			lastHit.collider.gameObject.GetComponent<MeshRenderer>().material = ballhd;
            //newAtom.ChangeText("");
        }
        reset = false;
			
	}
}
