using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosPersistentes : MonoBehaviour {
    /*  El objeto que posea este script no se destruye al pasar de una escena a otra.
     *  sirve para guardar datos que queramos modificar en una escen pero utilizar en otra
     */
    
    public static DatosPersistentes datosPers;  //variable que nos permite saber si ya hay un objeto de este tipo creado
    public int vida;
    public static GameObject arma;
    public  GameObject armaTest;
    public static int dinero;
    public static bool cargada = false;

    void Awake(){
        if (!cargada) {
            arma = armaTest;
            cargada = true;
        }
        

        if (datosPers == null){
            datosPers = this;
            // esta funcion le dice al objeto que posea este script que no se destruya al cargar una nueva escena
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
     
    }

}
