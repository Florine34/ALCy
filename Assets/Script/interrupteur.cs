using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interrupteur : MonoBehaviour {
    public bool active;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Si il y a un objet sur l'interrupteur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si c'est le joueur ou une caisse, alors on active l'interrupteur 
        if (collision.tag == "Player" || collision.tag == "Crate")
        {
            active = true;
        }
    
    }
}
