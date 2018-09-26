using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsNames : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        this.gameObject.GetComponent<Renderer>().enabled= false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    
    private void OnTriggerExit2D()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
