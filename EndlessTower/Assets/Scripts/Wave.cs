
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour {

    public GameObject indicadorOleada;      //Objeto que contiene la imagen que representa las oleadas
    public Animator anim;                   //Animator del objeto anterior

   public bool defeat = false;

    void OnEnable() {
        if (anim == null) {
            anim = indicadorOleada.GetComponent<Animator>();  //Asignamos el animator de nuestro icono a esta variable para manejarlo
        }


        anim.SetBool("Active",true); // si se entra en la funcion OnEnable quiere decir que la oleada empezo. por lo tanto
                                     // activamos la animacion del icono

    }


		void Update () {
         
        // Este codigo va dentro de un empty objet en el cual estan los enemigos de la oleada almacenados.
        // aca actualizacion se preguntara si esque aun tiene "hijos" ya que estos corresponded a los enemigos.
        // si no se encuentran hijos quiere decir que la oleada se vencio. por lo tanto activamos laanimacion de que la oleada 
        // ya esta derrotada




        if (!defeat) {
            if (gameObject.transform.childCount == 0) {
                defeat = true;
                anim.SetBool("Defeat", true);
           }
        }
	}
}
