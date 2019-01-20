using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DatosPersistentes : MonoBehaviour {

    
    public static DatosPersistentes datosPers; 
    public static GameObject arma;
    public GameObject armaTest;
    public static int dinero;
    public static int pisoMaximo;
    public static bool cargada = false;

    void Awake(){
        if (!cargada) {
            arma = armaTest;
            cargada = true;
        }
        

        if (datosPers == null){
            datosPers = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
     
    }

}
