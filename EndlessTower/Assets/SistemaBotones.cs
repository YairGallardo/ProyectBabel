using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(CharacterController))]
public class SistemaBotones : MonoBehaviour
{
 



    public GameObject botonSiguiente;
    public GameObject botonAnterior;
    public GameObject botonSiguiente1;
    public GameObject botonAnterior1;
    public GameObject Jugar;
    private GameObject _pc;

    public GameObject[] personajeArmas;
    public GameObject[] armas;
    GameObject play1;
    GameObject play1_1;




    // estas variables se usaran para saber donde estamos exactamente y activar o desactivar los botones.
    private int armaActual;
    private int armaAnterior;
    private int armaSiguiente;


   /* void Start() {
        //este codigo se ejecuta solo una vez 
        armaActual = armaAnterior = 0;
        armaSiguiente = armas.Length - 1;

        //como estamos en el inicio de la lista no hay anterior, asi que desactivamos el boton
        botonAnterior.SetActive(false);   
        //comprobamos que la lista tenga mas elementos que el primero
        //si tiene mas elemento activamos el boton siguiente, de no ser asi lo desactivamos.
        if (armaSiguiente == armaActual) {                                                                                               
            botonAnterior.SetActive(false); 
        } else {
            botonAnterior.SetActive(true);
        }
    }

    */






    public void ActivarAnterior()
    {
        botonAnterior.SetActive(false);
        botonSiguiente.SetActive(true);
        botonAnterior1.SetActive(false);
        botonSiguiente1.SetActive(false);

        armas[0].SetActive(true);
        personajeArmas[0].SetActive(true);
        armas[1].SetActive(false);
        personajeArmas[1].SetActive(false);
        armas[2].SetActive(false);
        personajeArmas[2].SetActive(false);
    }

    public void ActivarSiguiente()
    {
        armas[0].SetActive(false);
        personajeArmas[0].SetActive(false);
        armas[1].SetActive(true);
        personajeArmas[1].SetActive(true);
        armas[2].SetActive(false);
        personajeArmas[2].SetActive(false);

        botonSiguiente.SetActive(false);
        botonSiguiente1.SetActive(true);
        botonAnterior.SetActive(true);
    }

    public void ActivarAnterior1()
    {
        armas[0].SetActive(false);
        personajeArmas[0].SetActive(false);
        armas[1].SetActive(true);
        personajeArmas[1].SetActive(true);
        armas[2].SetActive(false);
        personajeArmas[2].SetActive(false);

        botonAnterior.SetActive(true);
        botonAnterior1.SetActive(false);
        botonSiguiente.SetActive(false);
        botonSiguiente1.SetActive(true);
    }

    public void ActivarSiguiente1()
    {
        armas[0].SetActive(false);
        personajeArmas[0].SetActive(false);
        armas[1].SetActive(false);
        personajeArmas[1].SetActive(false);
        armas[2].SetActive(true);
        personajeArmas[2].SetActive(true);

        botonAnterior.SetActive(false);
        botonAnterior1.SetActive(true);
        botonSiguiente.SetActive(false);
        botonSiguiente1.SetActive(false);
    }

    void Start()
    {
        botonSiguiente.SetActive(true);
        botonAnterior.SetActive(false);
        botonAnterior1.SetActive(false);
        botonSiguiente1.SetActive(false);

        armas[0].SetActive(true);
        personajeArmas[0].SetActive(true);
        armas[1].SetActive(false);
        personajeArmas[1].SetActive(false);
        armas[2].SetActive(false);
        personajeArmas[2].SetActive(false);
    }


    void Update()
    {

    }



}

