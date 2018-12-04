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
    public float atackDist;
    Animator anim;

	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody>();
        actualTime = followTime;
        follow = false;
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (follow)
        {
            Vector2 heroeV2 = new Vector2(heroe.position.x, heroe.position.z);
            Vector2 thisV2 = new Vector2(transform.position.x, transform.position.z);
            var tmp = heroeV2 - thisV2;
            var distancia = tmp.magnitude;

            if (distancia <= atackDist)
            {
                anim.SetBool("atack",true);
                StartCoroutine("stopAtack");

            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, heroe.position, vel * Time.deltaTime);
            }
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

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }*/



    IEnumerator stopAtack()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("atack", false);

    }




}
