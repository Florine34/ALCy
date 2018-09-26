using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill {

    public static void kill(GameObject gameObject)
    {
        Debug.Log("KILL");
        gameObject.SetActive(false);
        //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(Logique.currentSceneName);
    }
}
