using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logique : MonoBehaviour {

    static Logique instance;
    public Vector3 startPosition;
    //public string sceneName;
    public string sceneName;
    public int secteur;
    public int lvl;

    // Use this for initialization
    void Awake () {
        //var lvl = PlayerPrefs.GetInt("level", 1);
        //var secteur = PlayerPrefs.GetInt("secteur", 1);
        sceneName = "Level " + secteur + "-" + lvl;
#if UNITY_EDITOR
        //var editor = UnityEditor.SceneManagement.EditorSceneManager.GetSceneManagerSetup();
        //Debug.Log(editor);
#endif
        if (instance != null  && sceneName==instance.sceneName)
         {
             Destroy(gameObject);
             return;
         }
        else if(instance != null)
        {
            Destroy(instance.gameObject);
        }
         instance = this;
        DontDestroyOnLoad(gameObject);
        Kill.kill(null);
#if !UNITY_EDITOR
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
#endif
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static string currentSceneName
    {
        get
        {
            return instance.sceneName;
        }
    }
    public static Vector3 currentStartPosition
    {
        get
        {
            return instance.startPosition;
        }
    }

}
