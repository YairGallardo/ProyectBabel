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
    public GameObject player1;
    private GameObject _pc;
    GameObject play1;
    public GameObject player2;
    GameObject play2;
    public GameObject player3;
    GameObject play3;

    public void ActivarAnterior()
    {

        Destroy(play2, 0);
        Destroy(play3, 0);
        play1 = Instantiate(player1, new Vector3(3.95f, 1.49f, -0.98f), Quaternion.identity) as GameObject;
        botonAnterior.SetActive(false);
        botonSiguiente.SetActive(true);
        botonAnterior1.SetActive(false);
        botonSiguiente1.SetActive(false);
    }

    public void ActivarSiguiente()
    {

        Destroy(play1, 0);
        Destroy(play3, 0);
        play2 = Instantiate(player2, new Vector3(3.95f, 1.49f, -0.98f), Quaternion.identity) as GameObject;
        botonSiguiente.SetActive(false);
        botonSiguiente1.SetActive(true);
        botonAnterior.SetActive(true);
    }

    public void ActivarAnterior1()
    {

        Destroy(play1, 0);
        Destroy(play3, 0);
        play2 = Instantiate(player2, new Vector3(3.95f, 1.49f, -0.98f), Quaternion.identity) as GameObject;
        botonAnterior.SetActive(true);
        botonAnterior1.SetActive(false);
        botonSiguiente.SetActive(false);
        botonSiguiente1.SetActive(true);
    }

    public void ActivarSiguiente1()
    {

        Destroy(play1, 0);
        Destroy(play2, 0);
        play3 = Instantiate(player3, new Vector3(3.95f, 1.49f, -0.98f), Quaternion.identity) as GameObject;
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
        play1 = Instantiate(player1, new Vector3(3.95f, 1.49f, -0.98f), Quaternion.identity) as GameObject;
    }


    void Update()
    {
        //		GameObject tg = GameObject.FindGameObjectWithTag ("Player");
        //		tg.GetComponent<Animator> ().enabled = true;
        //		tg.GetComponent<ThirdPersonCharacter> ().enabled = true;
    }
}

