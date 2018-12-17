using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
    public Camera camera;



	// Use this for initialization
	void Start () {
        camera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(new Vector3(transform.position.x,camera.transform.position.y, camera.transform.position.z));
	}
}
