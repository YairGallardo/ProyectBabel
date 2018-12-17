using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDatos : MonoBehaviour {
    private int dinero;
    public GameObject arma;

	void Update () {
		
	}




    public int getDinero() {
        return dinero;
    }

    public void restDinero(int cobro){
        dinero -= Mathf.Abs(cobro);
    }


}
