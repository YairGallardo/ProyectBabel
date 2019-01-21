using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour {
    [Header("Estadisticas enemigo")]
    public int vidaMaxima;
    public int vel;
    public int recompenza;
    public int ataque;


    [Header("Elementos UI")]
    public Slider sbarraDeVida;
    public int vidaActual;
    public GameObject dañoVisual;


    public void recibirDaño(int daño) {
        dañoVisual.transform.GetChild(0).gameObject.GetComponent<Text>().text = daño + "";
        var tmpDaño = Instantiate(dañoVisual,transform.position,dañoVisual.transform.rotation);
        Destroy(tmpDaño,3f);


        vidaActual -= daño;
        sbarraDeVida.value = vidaActual;
        if (vidaActual <= 0) {
            muerte();
        }
    }

    public void muerte() {
        FindObjectOfType<ControladorNivel>().botinAcumulado += recompenza;
        Destroy(gameObject);
    }
}
