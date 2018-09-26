using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleIA_move : MonoBehaviour {

    public string sceneName;
    public int lifePoints;
    bool direction;
    public float speed;
    public Collider2D zoneA;
    public Collider2D zoneB;
    public float knockBackTime;
    public float knockBackSpeed;
    private float knockBackRemaining;
    private float knockBackDirection;

	// Use this for initialization
	void Start () {
        direction = true;
        Debug.Log(direction);
        //
	}
	
	// Update is called once per frame
	void Update () {
        var s = speed*Time.deltaTime;
        var knockBack = Vector3.zero;

        if (knockBackRemaining > 0)
        {
            knockBack = Vector3.right * knockBackSpeed * Time.deltaTime * knockBackDirection;
            knockBackRemaining -= Time.deltaTime;
        }

        if (direction)
        {
            transform.Translate(new Vector3(-s, 0, 0) + knockBack);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(!direction)
        {
            transform.Translate(new Vector3(s, 0, 0) + knockBack);
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag=="DmgToBot")
        {
            lifePoints--;
            if (lifePoints<=0)
            {
                Destroy(gameObject);
            }
            else
            {
                //knockback
                var dir = 5;
                if (!direction)
                {
                    dir = -dir;
                }
                knockBackRemaining = knockBackTime;
                knockBackDirection = other.transform.position.x > transform.position.x ? -1f : 1f;
                //gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(dir, 0),ForceMode2D.Impulse);
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
        else
        {
            direction = !direction;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "DmgToBot")
        {
            lifePoints--;
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                //knockback
                var dir = 205;
                if (direction)
                {
                    dir = -dir;
                }
                gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(dir, 0), ForceMode2D.Impulse);
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
            //gameObject.SetActive(false);
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(1);
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            Kill.kill(gameObject);
        }
        else
        {
            direction = !direction;
        }
    }
}
