using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControladorMenusNivel : MonoBehaviour {
    [Header("Menús")]
    public GameObject menuVictoria;
    public GameObject menuDerrota;
    public GameObject menuPausa;
    [Header("Nombres escenas")]
    public string siguienteNivel;
    public string menuPrincipal;
    [Header("Botones interaccion")]
    public Button botonPausa;


    private Animator anim;


    //Habilitacion de Menus
    public void activarMenuPausa(){
        menuPausa.SetActive(true);
        anim = menuPausa.GetComponent<Animator>();
        StartCoroutine("mostrarMenu");
        desactivarBotones();
    }

    public void activarMenuVictoria(){
        menuVictoria.SetActive(true);
        anim = menuPausa.GetComponent<Animator>();
        StartCoroutine("mostrarMenu");
        desactivarBotones();
    }

    public void activarMenuDerrota(){
        menuDerrota.SetActive(true);
        anim = menuPausa.GetComponent<Animator>();
        StartCoroutine("mostrarMenu");
        desactivarBotones();
    }
    //Deshabilitacion de Menus
    public void desactivarMenuPausa() {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        activarBotones();
    }


    // Acciones asociadas a botones de los menus
    void activarBotones(){
        botonPausa.enabled = true;
    }

    void desactivarBotones(){
        botonPausa.enabled = false;
    }


    public void repetirNvl() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void siguienteNvl() {
        Time.timeScale = 1f;
        DatosPersistentes.dinero += FindObjectOfType<ControladorNivel>().botinAcumulado;
        SceneManager.LoadScene(siguienteNivel);
    }

    public void abandonarNvl()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuPrincipal);
    }

    IEnumerator mostrarMenu()
    {
        anim.SetBool("anim", true);
        yield return new WaitForSeconds(.2f);
        Time.timeScale = 0f;
        anim.SetBool("anim", false);

    }










}
