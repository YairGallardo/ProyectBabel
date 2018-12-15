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

    void Awake(){
        //verificamos si ya tenemos un objeto con datos guardados
        //si no es asi lo creamos
        // si ya existe nos destruimos para no perder lo que ya esta creado
        /*
        if (datosPers == null){
            datosPers = this;
            // esta funcion le dice al objeto que posea este script que no se destruya al cargar una nueva escena
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        ¨*/
    }

}
