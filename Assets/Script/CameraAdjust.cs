using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAdjust : MonoBehaviour {
    public float desiredWidth;

    Camera camera;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        float ratio = (float) Screen.height / Screen.width;
        camera.orthographicSize = ratio * desiredWidth;
	}
}
