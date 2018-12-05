using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorOleada : MonoBehaviour {


    public GameObject indicadorOleada;      //Objeto que contiene la imagen que representa las oleadas (en UI)
    private Animator anim;                  //Animator del objeto anterior
    bool completada;                        //indica si la oleada ya se ha derrotado completamente

    void Start()
    {
        completada = false;    
    }

    void OnEnable()
    {
        /* Este codigo solo se ejecuta cuando el objeto es activado
         * gameobject.SetActive(true) */

        /* Asignamos el animator de nuestro icono a esta variable para manejarlo */
        anim = indicadorOleada.GetComponent<Animator>();  

        /* si se entra en la funcion OnEnable quiere decirque la oleada empezo. 
         * por lo tanto activamos la animacion del icono */
        anim.SetBool("Active", true); 
    }


    void Update()
    {
        /* Este codigo va dentro de un empty object en el cual estan los enemigos de la oleada almacenados.
         * aca actualizacion se preguntara si aun tiene "hijos" ya que estos corresponded a los enemigos.
         * si no se encuentran hijos quiere decir que la oleada se vencio. por lo tanto activamos la animacion 
         * de que la oleada ya esta derrotada 
         */
        if (!completada)
        {
            if (gameObject.transform.childCount == 0)
            {
                completada = true;
                anim.SetBool("Defeat", true);
            }
        }
    }

    public bool oleadaCompletada() {
        /* Retorna el estado de la variable completada.
         * Pensado para usarce en la verificacion de juego completado
         */

        return completada;
    }
}
