using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour {
    [Header("Estadisticas")]
    public string nombre;                           // Nombre del arma dentro del juego
    public int ataque;                              // Puntos de ataque del arma
    public string elemento = "Normal";   // Elemento del Arma


    [Header("ElementosVisuales")]
    public Sprite imagenArma;                       // Imagen que se muestra en la ventana de seleccion de arma
    public Sprite imagenhabilidad;                  // Icono de Habilidad cargada que ira en el boton
    public GameObject efectoBasico;                 // Particulas que muestran la traza del arma (no se si dejarlo)
    public GameObject efectoAtaqueEspecial;         // Efecto se genera al realizar el ataque especial

    public void ataqueEspecial() {
        Debug.Log("ataque EN ARMAAAA");
        GameObject tmp = Instantiate(efectoAtaqueEspecial, FindObjectOfType<Player>().transform.position, efectoAtaqueEspecial.transform.rotation);
        tmp.GetComponent<EfectoArmaBasico>().daño = ataque / 4;
        Destroy(tmp,5f);
    }

}
