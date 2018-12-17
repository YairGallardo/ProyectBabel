using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionMenuDos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void cargarSiguiente2(string CargaString2)
    {
        SceneManager.LoadScene(CargaString2);
    }

}
