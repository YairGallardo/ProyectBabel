using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarBotin : MonoBehaviour {
    public Text t_botin;
    public bool derrota = false;

	void Update () {

        if (derrota)
        {
            t_botin.text = FindObjectOfType<ControladorNivel>().botinAcumulado/10 + "";
        }
        else {
            t_botin.text = FindObjectOfType<ControladorNivel>().botinAcumulado + "";
        }
        
	}
}
