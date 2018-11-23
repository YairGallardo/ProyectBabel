using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

    public Transform heroe;
    public int vel;
    public Rigidbody body;


	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody>(); 
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, heroe.position, vel*Time.deltaTime);
        
    }



    /// Esta funcion se ejecuta cuando el objeto choca con otro.
    /// //comos e ve , preguntamos si choco con un objeto tageado como "player" si la respuesta es si
    /// Elimino el enemigo ... esto solo para testear cosillas
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
