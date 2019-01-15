using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
    [Header("Estadisticas")]
    public string codigo;                           // Codigo de identificacion. Usado en la BD de armas
    public string nombre;                           // Nombre del arma dentro del juego
    public string descripcion;                      // Descripcion "historia" del arma
    public int ataque;                              // Puntos de ataque del arma
    public string elemento = "Normal";   // Elemento del Arma
    public int probEfecto;                          // % de que se active el efecto asociado al elemento del arma
                                                    // Ejm : 5% de quemar si es elemento Fuego.

    public string precio;

    [Header("ElementosVisuales")]
    public Sprite imagenArma;                       // Imagen que se muestra en la ventana de seleccion de arma
    public Sprite imagenhabilidad;                  // Icono de Habilidad cargada que ira en el boton
    public GameObject efectoBasico;                 // Particulas que muestran la traza del arma (no se si dejarlo)
    public GameObject efectoAtaqueEspecial;         // Efecto se genera al realizar el ataque especial


    bool aplicarEfecto() {
        // Esta funcion se utilizara para saber si al atacar un enemigo, este recibira
        // el efecto asociado al elemento del arma.
        // si el arma es normal se enviara falso, ya que este tipo de armas no rpoducen efectos
        bool resp = false;
        int random = Random.Range(0,100);
        if ((elemento != "Normal") && (probEfecto >= random)) {
            resp = true;
        }
        return resp;
    }




    public void ataqueInicio(){
        gameObject.GetComponent<BoxCollider>().enabled = true;
        efectoBasico.SetActive(true);
    }


    public void ataqueFin(){
        gameObject.GetComponent<BoxCollider>().enabled = false;
        efectoBasico.SetActive(false);
    }

    public void ataqueEspecial() {
        Debug.Log("ataque EN ARMAAAA");
        GameObject tmp = Instantiate(efectoAtaqueEspecial, FindObjectOfType<Player>().transform.position, efectoAtaqueEspecial.transform.rotation);
            Destroy(tmp,5f);
    }


    private void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Enemy"){
            Enemigo tmp = col.gameObject.GetComponent<Enemigo>();
            tmp.recibirDaño(ataque);
        }
    }






}
