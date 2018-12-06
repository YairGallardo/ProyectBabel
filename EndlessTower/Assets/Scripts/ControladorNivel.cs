using UnityEngine;
using UnityEngine.UI;

public class ControladorNivel : MonoBehaviour {


    [Header("Scripts")]
    public ControladorOleadas controladorOleadas;
    public Player jugador;
    public PlayerMovment jugadorMov;
    public ControladorMenusNivel controladorMenus;  

    [Header("Elementos UI")]
    public Text t_tiempoEsperaInicio;

    [Header("vars")]
    public int tiempoEsperaInicio;


    //variables de control
    float tiempoActual;
    bool nivelIniciado;

    bool tiempoAgotado;
    bool nivelSuperado;

    bool jugadorMuerto;

	void Start () {
        tiempoAgotado = false;
        nivelSuperado = false;
        jugadorMuerto = false;
        controladorOleadas.enabled  = false;
        jugador.enabled     = false;
        jugadorMov.enabled          = false;
        nivelIniciado = false;
        tiempoActual = tiempoEsperaInicio;
        t_tiempoEsperaInicio.text = tiempoEsperaInicio.ToString();
	}
	
	void Update () {
        if (nivelIniciado){
            if (!nivelSuperado && !tiempoAgotado && !jugadorMuerto) {
                if (controladorOleadas.nivelCompletado()) {
                    nivelSuperado = true;
                    nivelCompletado();

                } else if (controladorOleadas.tiempoTerminado()) {
                    tiempoAgotado = true;
                    tiempoNivelAgotado();
                } else if (jugador.jugadorEstaMuerto()) {
                    jugadorMuerto = true;
                    jugadorDerrotado();

                }
            }
        }else {
            if (tiempoActual <= 0) {
                iniciarNivel();
            } else{
                tiempoActual -= Time.deltaTime;
                t_tiempoEsperaInicio.text = tiempoActual.ToString("0.0");
            }
        }
	}






    void iniciarNivel() {
        controladorOleadas.enabled = true;
        jugador.enabled = true;
        jugadorMov.enabled = true;
        t_tiempoEsperaInicio.enabled = false;
        nivelIniciado = true;
    }

    void nivelCompletado() {
        controladorMenus.activarMenuVictoria();
    }

    void tiempoNivelAgotado() {
        controladorMenus.activarMenuDerrota();
    }

    void jugadorDerrotado()
    {
        controladorMenus.activarMenuDerrota();
    }

}
