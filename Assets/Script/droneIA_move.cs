using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneIA_move : MonoBehaviour {
    //public
    bool detect;
    public float detectZone;
    bool direction;
    public float speed;
    public Collider2D zoneA;
    public Collider2D zoneB;
    public GameObject player;
    public int lifePoints;
    

    // Use this for initialization
    void Start () {
        detect = false;
        direction = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (direction && !detect)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        else if (!direction && !detect)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else if (detect)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
        }

       if (Vector3.Distance(player.transform.transform.position, transform.position) < detectZone)
        {
            Debug.Log("DETECTED");
            detect = true;
        }






    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /*
        if (other == zoneA)
        {
            direction = false;
        }
        else if (other == zoneB)
        {
            direction = true;
        }
        */
        direction = !direction;
        if (other.collider.tag == "DmgToBot")
        {
            lifePoints--;
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                //knockback
                var dir = 5;
                if (direction)
                {
                    dir = -dir;
                }
                gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(dir, 0), ForceMode2D.Impulse);
            }
        }
        else if (other.collider.tag == "Player")
        {
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
            //gameObject.SetActive(false);
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(1);
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            Kill.kill(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other == zoneA)
        {
            direction = false;
        }
        else if (other == zoneB)
        {
            direction = true;
        }
        */
        direction = !direction;
        if (other.tag == "DmgToBot")
        {
            lifePoints--;
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                //knockback
                var dir = 5;
                if (direction)
                {
                    dir = -dir;
                }
                gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(dir, 0), ForceMode2D.Impulse);
            }
        }
        else if (other.tag == "Player")
        {
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
            //gameObject.SetActive(false);
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(1);
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            Kill.kill(gameObject);
        }
    }
}
