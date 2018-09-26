using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinLvl : MonoBehaviour {
    public int secteur;
    public int lvl;
    public bool isEndSector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(PlayerPrefs.GetInt("level"));
        Debug.Log(PlayerPrefs.GetInt("secteur"));
        if (PlayerPrefs.GetInt("level",1)==lvl && PlayerPrefs.GetInt("secteur ", 1) == secteur)
        {
            if (isEndSector)
            {
                //fin du secteur --> secteur ++ et lvl =1
                PlayerPrefs.SetInt("secteur", secteur++);
                PlayerPrefs.SetInt("level", 1);
                //UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + (secteur+1)+"-1" );
                UnityEngine.SceneManagement.SceneManager.LoadScene("Section" + secteur);
            }
            else
            {
                //fin du niveau --> meme secteur mais lvl++
                PlayerPrefs.SetInt("level", lvl+1);
                PlayerPrefs.SetInt("secteur", secteur);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + (secteur) + "-" + (lvl + 1));
            }
        }
        else
        {
            //LOAD HUB
            if (isEndSector)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Section" + secteur);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + (secteur) + "-" + (lvl + 1));
            }
        }
        
    }
}
