using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoHongo : VarsEnemy,IEnemy
{
    public float atackDist;
    public Transform heroe;
    public Rigidbody body;
    bool inCorout;
    bool muerto;

    void Start(){
        heroe = FindObjectOfType<PlayerMovment>().transform;
        vidaActual = vidaMaxima;
        sbarraDeVida.maxValue = vidaMaxima;
        sbarraDeVida.value = vidaMaxima;
        body = gameObject.GetComponent<Rigidbody>();
        inCorout = false;
        muerto = false;
    }

    // Update is called once per frame
    void Update(){
        if (!muerto)
        {
            Vector2 heroeV2 = new Vector2(heroe.position.x, heroe.position.z);
            Vector2 thisV2 = new Vector2(transform.position.x, transform.position.z);
            var tmp = heroeV2 - thisV2;
            var distancia = tmp.magnitude;

            if (distancia <= atackDist)
            {
                StartCoroutine("atack");
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, heroe.position, vel * Time.deltaTime);
            }
            transform.LookAt(new Vector3(heroe.position.x, transform.position.y, heroe.position.z));
        }
    }


    IEnumerator atack() {
        if (!inCorout) {
            inCorout = true;
            MushroomMon_Ani_Test anim = GetComponent<MushroomMon_Ani_Test>();
            anim.AttackAni();
            yield return new WaitForSeconds(1);
            anim.RunAni();
            inCorout = false;
        }
    }


    public void recibirDaño(int daño){
        dañoVisual.transform.GetChild(0).gameObject.GetComponent<Text>().text = daño + "";
        var tmpDaño = Instantiate(dañoVisual, transform.position, dañoVisual.transform.rotation);
        Destroy(tmpDaño, 3f);
        vidaActual -= daño;
        sbarraDeVida.value = vidaActual;
        Debug.Log(daño);
        if (vidaActual <= 0){
            muerte();
        }
    }

    public void muerte() {
        muerto = true;
        FindObjectOfType<ControladorNivel>().botinAcumulado += recompenza;
        Destroy(gameObject,1);
        MushroomMon_Ani_Test anim = GetComponent<MushroomMon_Ani_Test>();
        anim.DeathAni();
        this.vel = 0;
        this.ataque = 0;
    }



}
