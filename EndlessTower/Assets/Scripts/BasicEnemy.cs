using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

    public Transform heroe;
    public int vel;
    public Rigidbody body;
    public float followTime = 2f;
    float actualTime;
    bool follow;

	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody>();
        actualTime = followTime;
        follow = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (follow)
        {
            transform.position = Vector3.MoveTowards(transform.position, heroe.position, vel * Time.deltaTime);
            transform.LookAt(new Vector3 (heroe.position.x, transform.position.y,heroe.position.z));
        }


        if (actualTime <= 0)
        {
            if (Random.Range(0, 100) > 50)
            {
                follow = true;
            }
            else {
                follow = false;
            }

            actualTime = followTime;
            
        }
        else {
            actualTime -= Time.deltaTime;
        }
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
