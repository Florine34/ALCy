using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var player = gameObject;
        /*var log = GameObject.Find("Logique");
        Debug.Log(log);
        var pos = log.GetComponent<Logique>().startPosition;
        Debug.Log(pos);*/
        var pos = Logique.currentStartPosition;
        player.transform.position = pos;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
