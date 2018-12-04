using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarPersonaje : MonoBehaviour {

    public float velRotacion;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3 (0,velRotacion,0));
	}
}
