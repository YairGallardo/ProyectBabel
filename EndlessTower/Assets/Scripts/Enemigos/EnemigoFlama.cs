using System.Collections;

using UnityEngine;
using UnityEngine.UI;


public class EnemigoFlama : VarsEnemy, IEnemy
{
    public float atackDist;
    public Transform heroe;
    public Rigidbody body;
    bool inCorout;
    bool muerto;
    int rand=0;

    Vector3 direction;




    void Start(){
        heroe = FindObjectOfType<PlayerMovment>().transform;
        vidaActual = vidaMaxima;
        sbarraDeVida.maxValue = vidaMaxima;
        sbarraDeVida.value = vidaMaxima;
        body = gameObject.GetComponent<Rigidbody>();
        inCorout = false;
        muerto = false;
        randomVector();
    }


    void FixedUpdate()
    {
        if (!muerto && !inCorout ){
            Vector2 heroeV2 = new Vector2(heroe.position.x, heroe.position.z);
            Vector2 thisV2 = new Vector2(transform.position.x, transform.position.z);
            var tmp = heroeV2 - thisV2;
            var distancia = tmp.magnitude;
            if (distancia <= atackDist) {
                StartCoroutine("atack");
            } else{
                body.velocity = direction * vel * Time.deltaTime;
            }
            
        }
    }


    public void randomVector() {

        Vector3[] dirs = {
            new Vector3(1,0,0),
            new Vector3(1,0,1),
            new Vector3(-1,0,0),
            new Vector3(-1,0,1),
            new Vector3(0,0,1),
            new Vector3(0,0,-1),
        };
        bool ok = false;
        while (!ok) {
            Random rd = new Random();
            int newrand = Random.Range(0, dirs.Length);
            
            if (newrand != rand) {
                ok = true;
                rand = newrand;
            }

        }
        direction = dirs[rand];
        Vector3 lookAtDir = new Vector3(transform.position.x+direction.x, transform.position.y,transform.position.z+direction.z);



        transform.LookAt(lookAtDir);

    }


    IEnumerator atack()
    {
        if (!inCorout)
        {
            Debug.Log("Ataque");
            inCorout = true;
            Animation_Test anim = GetComponent<Animation_Test>();
            anim.AttackAni();
            transform.LookAt(new Vector3(heroe.transform.position.x,transform.position.y, heroe.transform.position.z));
            body.velocity = Vector3.zero;
            yield return new WaitForSeconds(1);
            anim.RunAni();
            inCorout = false;




            Vector2 heroeV2 = new Vector2(heroe.position.x, heroe.position.z);
            Vector2 thisV2 = new Vector2(transform.position.x, transform.position.z);
            var tmp = heroeV2 - thisV2;
            var distancia = tmp.magnitude;
            if (distancia > atackDist) {
                randomVector();
            }
        }
    }



    public void recibirDaño(int daño)
    {
        dañoVisual.transform.GetChild(0).gameObject.GetComponent<Text>().text = daño + "";
        var tmpDaño = Instantiate(dañoVisual, transform.position, dañoVisual.transform.rotation);
        Destroy(tmpDaño, 3f);
        vidaActual -= daño;
        sbarraDeVida.value = vidaActual;
        Debug.Log(daño);
        if (vidaActual <= 0)
        {
            muerte();
        }
    }

    public void muerte()
    {
        muerto = true;
        FindObjectOfType<ControladorNivel>().botinAcumulado += recompenza;
        Destroy(gameObject, 1);
        Animation_Test anim = GetComponent<Animation_Test>();
        anim.DeathAni();
        this.vel = 0;
        this.ataque = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pared") {
            randomVector();
        }
        
    }
}
