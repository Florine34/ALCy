using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Vector3 RespawnPoint;
    public Sprite notcheckedyet;
    private bool check = false;

    // Use this for initialization
    void Start () {
        //cant play
        /*
        if (!check)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = notcheckedyet;
        }*/
        
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (!check)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = notcheckedyet;
        }*/
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            //On modifie de respawn
            Debug.Log("checkpoint1");
            var logique = GameObject.Find("Logique");
            logique.GetComponent<Logique>().startPosition = RespawnPoint;
            check = true;
            changeSprite();
        }
    }

    public void changeSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = notcheckedyet;
    }
}
