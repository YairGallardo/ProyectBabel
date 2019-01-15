using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public bool modoJuego;

    [Header("Estadisticas jugador")]
    public int vidaMaxima=100;
    public int puntosAtaque;
    public float cdAtaqueBasico;
    public float cdAtaqueEspecial;
    public Transform posicionEspada;

    [Header("ElementosUI")]
    public Slider sliderVida;
    public Slider sAtaqueBasico;
    public Slider sAtaqueEspecial;

    //
    Animator anim;
    PlayerMovment move;
    AudioSource audio;
    //variables de control
    public int vidaActual;
    private bool jugadorMuerto;

    private float cdBasicoActual;
    private float cdEspecialActual;
    private Arma myArma;

    // Use this for initialization


  


    void Start () {
        equiparArma();
        move = gameObject.GetComponent<PlayerMovment>();
        audio = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        vidaActual = vidaMaxima;
        
        if (modoJuego)
        {
            myArma = FindObjectOfType<Arma>();
            jugadorMuerto = false;
            sliderVida.maxValue = vidaMaxima;
            sliderVida.value = vidaMaxima;

            cdBasicoActual = cdAtaqueBasico;
            cdEspecialActual = 0;

            sAtaqueBasico.maxValue = cdAtaqueBasico;
            sAtaqueEspecial.maxValue = cdAtaqueEspecial;
            sAtaqueEspecial.value = cdEspecialActual;
            sAtaqueBasico.value = cdAtaqueBasico;
        }
        else {

        }


    }

    void Update()
    {
        if (vidaActual <= 0 ) {

            PlayerDie();
            jugadorMuerto = true;
        }

        if (cdBasicoActual < cdAtaqueBasico) {
            cdBasicoActual += Time.deltaTime;
            sAtaqueBasico.value = cdBasicoActual;
        }

        if (cdEspecialActual < cdAtaqueEspecial)
        {
            cdEspecialActual += Time.deltaTime;
            sAtaqueEspecial.value = cdEspecialActual;
        }



    }






    public void BasicAtack() {

        if (cdBasicoActual >= cdAtaqueBasico) {
            myArma.ataqueInicio();
            cdBasicoActual = 0;
            //audio.Play();
            anim.SetBool("bAtack", true);
            StartCoroutine("stopBAtack");
        }
        
    }

    public void SpecialAtack() {
        Debug.Log("ataque especial");
        if (cdEspecialActual >= cdAtaqueEspecial) {
            Debug.Log("ejecutado");
            myArma.ataqueEspecial();
            cdEspecialActual = 0;
            anim.SetBool("sAtack", true);
            StartCoroutine("stopSAtack");
        }

        
    }

    public void PlayerHurt() {
        anim.SetBool("hurt", true);
    }


    public void PlayerDie() {
        anim.SetBool("die", true);
    }


    IEnumerator stopBAtack()
    {
        yield return new WaitForSeconds(.3f);
        anim.SetBool("bAtack", false);
        myArma.ataqueFin();

    }

    IEnumerator stopSAtack()
    {
        yield return new WaitForSeconds(.3f);
        anim.SetBool("sAtack", false);

    }

    public bool jugadorEstaMuerto() {
        return jugadorMuerto;
    }

    public void recibirDaño(int daño)
    {
        vidaActual -= daño;
        sliderVida.value = vidaActual;


        if (vidaActual <= 0)
        {
            //destruir;
            PlayerDie();
        }
    }


    void equiparArma()
    {
        Debug.Log("Equipando arma");

        if (DatosPersistentes.arma != null)
        {
            if (posicionEspada.childCount > 0)
            {
                foreach (Transform child in posicionEspada)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }


            var armaTmp = Instantiate(DatosPersistentes.arma, posicionEspada.position, posicionEspada.rotation);
            Debug.Log(armaTmp.name);
            armaTmp.transform.parent = posicionEspada;
        }
        else
        {
            Debug.Log("No hay arma en los datos persistentes");
        }
    }

}
