using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    PlayerMovment move;
    public int health=100;
    Animator anim;



	// Use this for initialization
	void Start () {
        move = gameObject.GetComponent<PlayerMovment>();
        anim = gameObject.GetComponent<Animator>();
	}

    void Update()
    {
        if (health <= 0 ) {

            PlayerDie();

        }   
    }






    public void BasicAtack() {
        anim.SetBool("bAtack",true);
        StartCoroutine("stopBAtack");
    }

    public void SpecialAtack() {
        anim.SetBool("sAtack", true);
        StartCoroutine("stopSAtack");
    }

    public void PlayerHurt() {
        anim.SetBool("hurt", true);
    }


    public void PlayerDie() {
        anim.SetBool("die", true);
    }


    IEnumerator stopBAtack()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("bAtack", false);

    }

    IEnumerator stopSAtack()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("sAtack", false);

    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy") {
            Destroy(col.gameObject);

        }
    }



}
