using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile : MonoBehaviour {
    private bool direction;
    public float speed;
    public Transform[] bornes;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var b in bornes)
        {
            float delta = transform.position.x - b.position.x;
            if (delta > 0f && delta < 0.5f)
                direction = false;
            if (delta < 0f && delta > -0.5f)
                direction = true;
        }

        var s = speed * Time.deltaTime;
        if (direction)
        {
            transform.Translate(new Vector3(-s, 0, 0));
        }
        else if (!direction)
        {
            transform.Translate(new Vector3(s, 0, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag!="Player")
        {
            direction = !direction;
        }
        if (collision.gameObject.tag=="Player")
        {
            //attache 
            collision.transform.SetParent(transform);
        }
        Debug.Log("rre");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //attache 
            collision.transform.SetParent(null);
        }
    }
    
}
