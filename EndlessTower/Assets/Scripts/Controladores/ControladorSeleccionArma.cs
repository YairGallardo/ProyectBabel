using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ControladorSeleccionArma : MonoBehaviour {

    [Header("variables")]
    public GameObject[] armas;
    public Transform posArmaHeroe;
    public Animator anim;

    [Header("Elementos UI")]
    public GameObject b_anterior;
    public GameObject b_siguiente;
    public Text t_nombreArma;
    public Text t_descArma;
    public Image imgArma;
    public Text cartelEquipada;


    // variables para el control
    [Header("Debug (no modificar)")]
    public int cantidadArmas;
    public int armaActual;
    public int armaAnterior;
    public int armaSiguiente;


    List<string[]> armasDetalle;

    void Start () {
        ControladorBD cBD = new ControladorBD();
        armasDetalle = cBD.obtenerInventario();
        cargarPrefabs();
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

    void cargarPrefabs() {

        int cantArmas = armasDetalle.Count;
        armas = new GameObject[cantArmas];
        int index = 0;
        foreach (string[] elemento in armasDetalle) {
            // [0] = Codigo
            // [1] = Nombre 
            // [2] = Descripcion
            // [3] = Elemento
            // [4] = Daño
            // [5] = Porcentaje
            string codigo = elemento[0];
            GameObject arma = Resources.Load(DatosPersistentes.rutaArmasPrefs + "/" + codigo) as GameObject;
            Arma detalles = arma.GetComponent<Arma>();
            detalles.nombre         = elemento[1];
            detalles.descripcion    = elemento[2];
            detalles.elemento       = elemento[3];
            detalles.ataque         = int.Parse(elemento[4]);
            detalles.probEfecto     = int.Parse(elemento[5]);

            armas[index] = arma;
            index++;
        }

        
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
        ejecutarAnimacion();
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
        ejecutarAnimacion();
    }

    void mostrarArma(int index) {
        Arma arma = armas[index].GetComponent<Arma>();
        t_nombreArma.text = arma.nombre;

        t_descArma.text = "Ataque   : " + arma.ataque + "\n" +
                          "Elemento : " + arma.elemento + "\n" +
                          "% efecto : " + arma.probEfecto + "%";




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

        if (armas[index].Equals(DatosPersistentes.arma))
        {
            cartelEquipada.enabled = true;
        }
        else {
            cartelEquipada.enabled = false;
        }
     


    }

    public void equiparArma() {
        //poner arma en el modelo.

        //aqui guardamos el arma en el objeto que no se destruye
       DatosPersistentes.arma = armas[armaActual];
        cartelEquipada.enabled = true;
    }

    public void cargarEscena(string s) {
        SceneManager.LoadScene(s);

    }

    void ejecutarAnimacion() {
        anim.SetBool("anim",true);
        StartCoroutine("pararAnimacion");
    }

    IEnumerator pararAnimacion()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("anim", false);

    }


}
