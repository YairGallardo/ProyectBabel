using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(CharacterController))]
public class SistemaBotones : MonoBehaviour
{
    /*
    public GameObject botonSiguiente;
    public GameObject botonAnterior;
    public GameObject botonSiguiente1;
    public GameObject botonAnterior1;
    public GameObject Jugar;
    public GameObject player1;
    private GameObject _pc;
    GameObject play1;
    public GameObject player2;
    GameObject play2;
    public GameObject player3;
    GameObject play3;

    public GameObject player1A;
    GameObject player_Arma1;
    public GameObject player2A;
    GameObject player_Arma2;
    public GameObject player3A;
    GameObject player_Arma3;
    */
    public GameObject botonSiguiente;
    public GameObject botonAnterior;
    public GameObject botonSiguiente1;
    public GameObject botonAnterior1;
    public GameObject Jugar;
  //  public GameObject player1;
    private GameObject _pc;

    public GameObject[] personajeArmas;
    public GameObject[] armas;
    GameObject play1;
    GameObject play1_1;



    public void ActivarAnterior()
    {
        /*
        Destroy(play2, 0);
        Destroy(play3, 0);
        Destroy(player_Arma2, 0);
        Destroy(player_Arma3, 0);

        play1 = Instantiate(player1, new Vector3(3.95f, 3.62f, -0.98f), Quaternion.identity) as GameObject;

        player_Arma1 = Instantiate(player1A, new Vector3(-4.37f, -0.9f, -3.03f), Quaternion.identity) as GameObject;
        */



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
        /*
        Destroy(play1, 0);
        Destroy(play3, 0);
        Destroy(player_Arma1, 0);
        Destroy(player_Arma3, 0);

        play2 = Instantiate(player2, new Vector3(3.95f, 2.73f, -0.98f), Quaternion.identity) as GameObject;

        player_Arma2 = Instantiate(player2A, new Vector3(-4.37f, -0.9f, -3.03f), Quaternion.identity) as GameObject;
        */
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
        /*
        Destroy(play1, 0);
        Destroy(play3, 0);
        Destroy(player_Arma1, 0);
        Destroy(player_Arma3, 0);

        play2 = Instantiate(player2, new Vector3(3.95f, 2.73f, -0.98f), Quaternion.identity) as GameObject;

        player_Arma2 = Instantiate(player2A, new Vector3(-4.37f, -0.9f, -3.03f), Quaternion.identity) as GameObject;
        */
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
        /*
        Destroy(play1, 0);
        Destroy(play2, 0);
        Destroy(player_Arma1, 0);
        Destroy(player_Arma2, 0);

        play3 = Instantiate(player3, new Vector3(4,4.739f,-0.98f), Quaternion.identity) as GameObject;

        player_Arma3 = Instantiate(player3A, new Vector3(-4.37f, -0.9f, -3.03f), Quaternion.identity) as GameObject;
        */
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
        /*

        play1 = Instantiate(player1, new Vector3(3.95f, 3.62f, -0.98f), Quaternion.identity) as GameObject;

        player_Arma1 = Instantiate(player1A, new Vector3(-4.37f, -0.9f, -3.03f), Quaternion.identity) as GameObject;
    
    */

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
        //		GameObject tg = GameObject.FindGameObjectWithTag ("Player");
        //		tg.GetComponent<Animator> ().enabled = true;
        //		tg.GetComponent<ThirdPersonCharacter> ().enabled = true;
    }
}

