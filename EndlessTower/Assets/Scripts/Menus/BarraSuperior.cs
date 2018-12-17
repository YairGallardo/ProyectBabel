using UnityEngine;
using UnityEngine.UI;

public class BarraSuperior : MonoBehaviour {
    public Text dinero;



	// Use this for initialization
	void Start () {
        dinero.text = DatosPersistentes.dinero+"";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
