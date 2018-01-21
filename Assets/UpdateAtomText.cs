using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateAtomText : MonoBehaviour {
    public TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<TextMeshProUGUI>().SetText("1UUN");
//        text = GetComponent<TextMeshProUGUI>();
	}

    public void ChangeText(string atom){
		gameObject.GetComponent<TextMeshProUGUI> ().SetText (atom);
	}
	
}
