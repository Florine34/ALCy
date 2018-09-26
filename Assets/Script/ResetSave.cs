using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetSave : MonoBehaviour {

    public Button myButton;

	// Use this for initialization
	void Start () {
        var b = myButton.GetComponent<Button>();
        b.onClick.AddListener(resetSave);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resetSave() {
        PlayerPrefs.DeleteAll();
    }
}
