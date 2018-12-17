using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarBotin : MonoBehaviour {
    public Text t_botin;

	void Update () {
        t_botin.text = FindObjectOfType<ControladorNivel>().botinAcumulado+"";
	}
}
