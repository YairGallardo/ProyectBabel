using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
    [Header("Estadisticas")]
    public string nombre;
    public int ataque;
    public string descripcion;
    public string precio;

    [Header("ElementosVisuales")]
    public Sprite imagenArma;
    public Sprite imagenhabilidad;
    public GameObject efectoBasico;
    public GameObject efectoAtaqueEspecial;



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


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy"){
            Enemigo tmp = col.gameObject.GetComponent<Enemigo>();
            tmp.recibirDaño(ataque);
        }
    }






}
