using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteLocked : MonoBehaviour {
    public int level;
    public int secteur;
    public Sprite locked;
    public string scene;
    private bool door;
    private bool isLoading;

    // Use this for initialization
    void Start () {
        var levelPlayer = PlayerPrefs.GetInt("level",1);
        var secteurPlayer = PlayerPrefs.GetInt("secteur", 1);
        if (levelPlayer >= level && secteurPlayer >= secteur)
        {
            //peut jouer ce lvl
            //door Open
            door = true;
        }else
        {
            //cant play
            door = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite= locked;
        }
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isLoading && Input.GetAxis("Vertical")>0f)
        {
            if (door)
            {
                SwitchScene(scene);
            }
        }
    }

    private void SwitchScene(string n)
    {
        isLoading = true;
        Debug.Log("CHARGEMENT DE " + n);
        UnityEngine.SceneManagement.SceneManager.LoadScene(n, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
