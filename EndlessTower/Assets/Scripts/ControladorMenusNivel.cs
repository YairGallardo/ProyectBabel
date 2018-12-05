using UnityEngine;
using UnityEngine.UI;

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


    //Habilitacion de Menus
    public void activarMenuPausa(){
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        desactivarBotones();
    }

    public void activarMenuVictoria(){
        menuVictoria.SetActive(true);
        desactivarBotones();
    }

    public void activarMenuDerrota(){
        menuDerrota.SetActive(true);
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














}
