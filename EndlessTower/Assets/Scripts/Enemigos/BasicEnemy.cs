using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy  : Enemigo {

    public float followTime = 2f;
    public float atackDist;
    //control
    AudioSource audio;

    public Transform heroe;
    public Rigidbody body;
    float actualTime;
    bool follow;
    
    Animator anim;

	// Use this for initialization
	void Start () {
        vidaActual = vidaMaxima;
        sbarraDeVida.maxValue = vidaMaxima;
        sbarraDeVida.value = vidaMaxima;
        body = gameObject.GetComponent<Rigidbody>();
        actualTime = followTime;
        follow = false;
        anim = gameObject.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (follow){
            Vector2 heroeV2 = new Vector2(heroe.position.x, heroe.position.z);
            Vector2 thisV2 = new Vector2(transform.position.x, transform.position.z);
            var tmp = heroeV2 - thisV2;
            var distancia = tmp.magnitude;

            if (distancia <= atackDist){
                anim.SetBool("atack", true);
                StartCoroutine("stopAtack");
            }else{
                transform.position = Vector3.MoveTowards(transform.position, heroe.position, vel * Time.deltaTime);
            }
            transform.LookAt(new Vector3(heroe.position.x, transform.position.y, heroe.position.z));

            if (!audio.isPlaying) {
                audio.Play();
            }   
        } else {
            if (audio.isPlaying){
                audio.Stop();
            }
        }


        if (actualTime <= 0){
            if (Random.Range(0, 100) > 50){
                follow = true;
            }else {
                follow = false;
            }
            actualTime = followTime;
            
        }else {
            actualTime -= Time.deltaTime;
        }
    }

    IEnumerator stopAtack()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("atack", false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<Player>().recibirDaño(ataque);
        }
    }
}
