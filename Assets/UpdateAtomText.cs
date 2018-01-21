using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateAtomText : MonoBehaviour {
    public TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "";
	}

    public void ChangeText(string atom)
    {
        text.text = atom;
    }
	
}
