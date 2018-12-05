using UnityEngine;
using UnityEngine.UI;

public class ControladorOleadas : MonoBehaviour {
    [Header("Configuracion Oleadas")]
    public float tiempoOleada;          //Tiempo entre una oleada y la siguiente
    public float tiempoJefe;            //Tiempo entre que se spawnea el boss y pierdes.
  
    [Header("Enemigos")]
    public GameObject[] oleadas;        //objeto que contiene las oleadas. se activan para que la oleada aparezca
    public GameObject jefePiso;

    [Header("Elementos UI asociados")]
    public Text t_tiempoRestantePiso;
    public Text t_tiempoRestanteOleada;
    public Slider sliderTiempo;

    //variables de control
    bool completado;            //Indica si todas las oleadas y el jefe han sido derrotados.
    bool tiempoAgotado;

    int cantidadOleadas;
    float tiempoTotal;                  //Tiempo total del nivel (suma tiempod e oleadas y jefe)
    float tiempoRestantePiso;
    float tiempoRestanteOleada;
    int siguienteOleada;


    void Start () {
        cantidadOleadas = oleadas.Length;
        tiempoTotal     = tiempoOleada * cantidadOleadas + tiempoJefe;
        //chekea cada oleada y la deshabilita para iniciar el nivel
        deshabilitarOleadas(); 
        // seteo de elementos visibles relacionados con las oleadas
        sliderTiempo.maxValue = tiempoTotal;
        sliderTiempo.value = tiempoTotal;
        tiempoRestantePiso = tiempoTotal;
        tiempoRestanteOleada = 0;
        siguienteOleada = 0;
        completado = false;
        tiempoAgotado = false;
	}
	

	void Update () {

        if (!completado && !tiempoAgotado){
            /* Mientras no se complete el nivel y no se haya perdido se ejecutara el siguiente codigo
             * si una de las dos variables pasa a ser verdadero se detiene la ejecucion y el juego 
             * cambiara al estado de "Nivel Superado" o "Nivel Fallado"
             */
            if (tiempoRestanteOleada <= 0){
                /* Si se agoto el tiempo de la oleada se verifica si quedan mas por invocar
                 * de ser asi. se invoca la siguiente oleada. 
                 * de lo contrario el jefe del piso es invocado
                 */
                if (siguienteOleada < cantidadOleadas) {
                    oleadas[siguienteOleada].SetActive(true);
                    siguienteOleada++;
                    tiempoRestanteOleada = tiempoOleada;
                }else {
                    jefePiso.SetActive(true);
                    tiempoRestanteOleada = tiempoJefe;
                }
            }else{
                //si el tiempo de la oleada no se ha agotado se continua reduciendo
                tiempoRestanteOleada -= Time.deltaTime; 
            }


            /* Verificamos si se agoto el tiempo total del nivel
             * si es asi, tiempo agotado pasa a ser TRUE, lo que detiene la ejecucion de este codigo
             * y la variable puede ser observada de otro script para asi terminar el nivel con game over
             */
            if (tiempoRestantePiso <= 0){
                tiempoAgotado = true;
                t_tiempoRestantePiso.text = "0";
                t_tiempoRestanteOleada.text = "0";
            }
            else {
                tiempoRestantePiso -= Time.deltaTime;
            }


            //Actualizacion de los tiempos mostrados en pantalla
            actualizarUI();
            //verificamos si todas las holeadas y el jefe fueron superadas.
            completado = verificarOleadas();
        }
	}


    bool verificarOleadas() {
        /* Verifica mediante el controlador de cada oleada en especifico si esta 
         * aun encuentra activa. 
         * Si todas las oleadas y el jefe han sido derrotados el nivel se ha completado
         */

        /* Se define un boleano de estado marcado en true suponiendo que se completaron todas
         * las oleadas y el jefe. Posteriormente se verifica sie esto es cierto.
         * Si almenos una oleada o el jefe aun no se han derrotado el estado se cambia a falso
         */
        bool estado = true;
   
        for (int i = 0; i < cantidadOleadas; i++){
            if (oleadas[i].GetComponent<ControladorOleada>().oleadaCompletada() == false) {
                estado = false;
            }
        }
        if (jefePiso.GetComponent<ControladorOleada>().oleadaCompletada() == false) {
            estado = false;
        }
        return estado;
    }


    void deshabilitarOleadas() {
        /*Recorre todo el arreglo de oleadas y desactiva cada una de ellas
         * incluyendo al jefe
         */
        for (int i =0; i< cantidadOleadas; i++) {
            oleadas[i].SetActive(false);
        }
        jefePiso.SetActive(false);
    }

    void actualizarUI() {
        //actualiza los elementos de la UI asociados al tiempo de las oleadas
        t_tiempoRestantePiso.text = tiempoRestantePiso.ToString("0.0"); 
        t_tiempoRestanteOleada.text = tiempoRestanteOleada.ToString("0.0");
        sliderTiempo.value = tiempoRestantePiso;
    }

    public bool nivelCompletado() {
        return completado;
    }

    public bool tiempoTerminado() {
        return tiempoAgotado;
    }


}
