using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ressort : MonoBehaviour {

    public Vector2 jumpForce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            var x = collision.GetComponent<Rigidbody2D>().velocity.x;
            //Debug.Log(collision.GetComponent<Rigidbody2D>().velocity.y);
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0f);
            collision.GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
        }
        if (collision.tag == "Crate")
        {
            var x = collision.GetComponent<Rigidbody2D>().velocity.x;
            //Debug.Log(collision.GetComponent<Rigidbody2D>().velocity.y);
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0f);
            collision.GetComponent<Rigidbody2D>().AddForce(jumpForce/2, ForceMode2D.Impulse);
        }

    }
}
