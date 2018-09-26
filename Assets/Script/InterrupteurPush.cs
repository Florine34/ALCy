using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupteurPush : MonoBehaviour {

    public GameObject porteToOpen;
    public GameObject visuel;
    public Sprite spriteOuvert;
    public Sprite spriteFerme;
    private bool triggerPlayer = false;
    private bool triggerCrate = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        /*
        var scale = visuel.transform.localScale;
        scale.y = 0.5f;*/
        if (collision.tag == "Crate")
        {
            triggerCrate = true;
            porteToOpen.GetComponent<porte>().open();
        }
        else if (collision.tag == "Player")
        {
            triggerPlayer = true;
            porteToOpen.GetComponent<porte>().open();
        }
        visuel.GetComponent<SpriteRenderer>().sprite = spriteOuvert;
        
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Crate" && triggerPlayer)
        {
            //porteToOpen.GetComponent<porte>().close();
            //visuel.GetComponent<SpriteRenderer>().sprite = spriteFerme;
            triggerCrate = false;
        }
        else if (collision.tag == "Player" && triggerCrate)
        {
            //porteToOpen.GetComponent<porte>().close();
            //visuel.GetComponent<SpriteRenderer>().sprite = spriteFerme;
            triggerPlayer = false;
        }
        else if (collision.tag == "Crate")
        {
            triggerCrate = false;
            porteToOpen.GetComponent<porte>().close();
            visuel.GetComponent<SpriteRenderer>().sprite = spriteFerme;
        }
        else if (collision.tag == "Player")
        {
            triggerPlayer = false;
            porteToOpen.GetComponent<porte>().close();
            visuel.GetComponent<SpriteRenderer>().sprite = spriteFerme;
        }
    }
}
