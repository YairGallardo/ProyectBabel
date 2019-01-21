using UnityEngine;
using UnityEngine.UI;

public class VarsEnemy : MonoBehaviour
{
    [Header("Estadisticas enemigo")]
    public int vidaMaxima;
    public float vel;
    public int recompenza;
    public int ataque;

    [Header("Elementos UI")]
    public Slider sbarraDeVida;
    public int vidaActual;
    public GameObject dañoVisual;
}
