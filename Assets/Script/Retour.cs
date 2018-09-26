using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retour : MonoBehaviour {
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwichScene(string name)
    {
        Debug.Log("RETOUR " + name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

}
