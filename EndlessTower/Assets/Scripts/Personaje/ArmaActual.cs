using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaActual : MonoBehaviour {
    // Este script equipa el arma actual al personaje.
    // esta separado para poder funcionar tanto en la batalla como en los menus 
    public Transform posicionEspada;
    public bool equipArma;

    void Start()
    {
        if (equipArma) {
            equiparArma();
        }
        
    }


    void equiparArma()
    {
        Debug.Log("Equipando arma");

        if (DatosPersistentes.arma != null)
        {
            if (posicionEspada.childCount > 0) {
                foreach (Transform child in posicionEspada)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }


            var armaTmp = Instantiate(DatosPersistentes.arma, posicionEspada.position, posicionEspada.rotation);
            Debug.Log(armaTmp.name);
            armaTmp.transform.parent = posicionEspada;
        }
        else
        {
            Debug.Log("No hay arma en los datos persistentes");
        }
    }
}
