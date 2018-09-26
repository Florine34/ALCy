using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class turretIA_behavior : MonoBehaviour {

    //private 
    private float timePassed;

    //public
    public float bulletSpeed;
    public float attackSpeed;
    public float detectionRange;

    public GameObject player;
    public GameObject projectilePrefab;




    // Use this for initialization
    void Start()
    {
        timePassed = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        //Si(Le joueur est dans la zone de detection && la tourelle a la vision)
        if (Vector3.Distance(player.transform.transform.position, transform.position) < detectionRange      &&      Physics2D.Linecast(transform.position, player.transform.position)) 
        {
            //direction du joueur
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            if (timePassed >= attackSpeed)
            {
                GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                timePassed = 0;
            }
            else
            {
                timePassed += Time.deltaTime;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("DEAD");
        }
    }
}
