using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorSeleccionArma : MonoBehaviour {

    [Header("variables")]
    public GameObject[] armas;
    public Transform posArmaHeroe;

    [Header("Elementos UI")]
    public GameObject b_anterior;
    public GameObject b_siguiente;
    public Text t_nombreArma;
    public Text t_descArma;
    public Image imgArma;


    // variables para el control
    [Header("Debug (no modificar)")]
    public int cantidadArmas;
    public int armaActual;
    public int armaAnterior;
    public int armaSiguiente;




    void Start () {

        b_anterior.SetActive(false);
        b_siguiente.SetActive(false);

        // seteo final botones y variables de control
        cantidadArmas = armas.Length;
        armaActual = armaAnterior = armaSiguiente = 0; //asumimos una lista con solo 1 arma por lo cual no hay sig ni anterior
        if (cantidadArmas > 1) {
            armaSiguiente = 1;  // vemos si existen mas de 1 arma 
        }
        // comprobamos si esxisten mas armas si es asi el boton siguiente sera habilitado

        if (armaSiguiente > armaActual) {
            b_siguiente.SetActive(true);
        }


        mostrarArma(0);

    }


    public void siguienteArma() {
        armaAnterior = armaActual;
        armaActual = armaSiguiente;
        if (armaSiguiente == cantidadArmas - 1){
            //si ya llegamos al ultima arma
            b_siguiente.SetActive(false);
        }else {
            armaSiguiente++;
        }

        if (!b_anterior.activeInHierarchy) {
            b_anterior.SetActive(true);
        }
        mostrarArma(armaActual);
    }

    public void anteriorArma() {
        armaSiguiente = armaActual;
        armaActual = armaAnterior;
        if (armaAnterior == 0){
            //si ya llegamos al ultima arma
            b_anterior.SetActive(false);
        }else{
            armaAnterior--;
        }
        if (!b_siguiente.activeInHierarchy){
            b_siguiente.SetActive(true);
        }
        mostrarArma(armaActual);
    }

    void mostrarArma(int index) {
        Arma arma = armas[index].GetComponent<Arma>();
        t_nombreArma.text = arma.nombre;
        imgArma.sprite = arma.imagenArma;


        if (posArmaHeroe.childCount > 0)
        {
            foreach (Transform child in posArmaHeroe)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        var armaTmp = Instantiate(armas[index],posArmaHeroe.position,posArmaHeroe.rotation);
        armaTmp.transform.parent = posArmaHeroe;

     


    }

    public void equiparArma() {
        //poner arma en el modelo.

        //aqui guardamos el arma en el objeto que no se destruye
       DatosPersistentes.arma = armas[armaActual];
    }

    public void cargarEscena(string s) {
        SceneManager.LoadScene(s);

    }


}
