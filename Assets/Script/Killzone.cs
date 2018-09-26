using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {
    public string sceneName;

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
            //gameObject.SetActive(false);
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(1);
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName,UnityEngine.SceneManagement.LoadSceneMode.Additive);
            Kill.kill(gameObject);
        }
        
    }
}
