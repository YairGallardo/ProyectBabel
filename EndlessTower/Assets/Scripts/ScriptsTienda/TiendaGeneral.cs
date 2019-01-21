using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaGeneral : MonoBehaviour
{
    public GameObject panelArmas;
    public GameObject panelArmasMejora;
    public GameObject panelScroll;
    public int posInicial = -980;
    public int saltoPos = 400;
    private int posActual;
    DatosDeArma[] armas;
    DatosDeArma[] mejoras;
    ControladorBaseDeArmas DB;
    public GameObject mensajeError;


    public GameObject botonMejora;
    public GameObject botonTienda;

    void Start()
    {
        posActual = posInicial;
        DB = FindObjectOfType<ControladorBaseDeArmas>();
        armas = DB.getEnVenta(); //en este punto tenemos una lista de objetos arma. cada una con sus atributos dentro

        foreach (DatosDeArma item in armas)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            // Generamos un panel que llevara dentro los datos del arma. 
            // añadimos ese panel al scroll para que quede todo en orden
            GameObject contenedor = Instantiate(panelArmas) as GameObject;
            contenedor.transform.SetParent(panelScroll.transform,false);
            contenedor.transform.localPosition = new Vector3(posActual,0, 0);
            
            contenedor.transform.localScale = new Vector3(1,1,1);
            posActual += saltoPos;
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // añadiremos los datos del arma al panel
            PanelArma detallesArma = contenedor.GetComponent<PanelArma>();
            detallesArma.modeloArma = item.arma;
            detallesArma.precio = item.niveles[0].precio;
            detallesArma.t_nombre.text = item.arma.GetComponent<Arma>().nombre;
            detallesArma.t_precio.text = "" + detallesArma.precio;
            detallesArma.t_descripcion.text = "LOREM";
            detallesArma.imagenArma.sprite = detallesArma.modeloArma.GetComponent<Arma>().imagenArma;
            detallesArma.codigoArma = item.index;
        }
    }

    public void recargar() {
        posActual = posInicial;
        foreach (Transform child in panelScroll.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        armas = DB.getEnVenta(); //en este punto tenemos una lista de objetos arma. cada una con sus atributos dentro

        foreach (DatosDeArma item in armas)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            // Generamos un panel que llevara dentro los datos del arma. 
            // añadimos ese panel al scroll para que quede todo en orden
            GameObject contenedor = Instantiate(panelArmas) as GameObject;
            contenedor.transform.SetParent(panelScroll.transform, false);
            contenedor.transform.localPosition = new Vector3(posActual, 0, 0);

            contenedor.transform.localScale = new Vector3(1, 1, 1);
            posActual += saltoPos;
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // añadiremos los datos del arma al panel
            PanelArma detallesArma = contenedor.GetComponent<PanelArma>();
            detallesArma.modeloArma = item.arma;
            detallesArma.precio = item.niveles[0].precio;
            detallesArma.t_nombre.text = item.arma.GetComponent<Arma>().nombre;
            detallesArma.t_precio.text = "" + detallesArma.precio;
            detallesArma.t_descripcion.text = "LOREM";
            detallesArma.imagenArma.sprite = detallesArma.modeloArma.GetComponent<Arma>().imagenArma;
            detallesArma.codigoArma = item.index;
        }


    }


    public void MostrarMejoras() {
        posActual = posInicial;
        foreach (Transform child in panelScroll.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        mejoras = DB.getMejoras (); //en este punto tenemos una lista de objetos arma. cada una con sus atributos dentro

        foreach (DatosDeArma item in mejoras)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            // Generamos un panel que llevara dentro los datos del arma. 
            // añadimos ese panel al scroll para que quede todo en orden
            GameObject contenedor = Instantiate(panelArmasMejora) as GameObject;
            contenedor.transform.SetParent(panelScroll.transform, false);
            contenedor.transform.localPosition = new Vector3(posActual, 0, 0);

            contenedor.transform.localScale = new Vector3(1, 1, 1);
            posActual += saltoPos;
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // añadiremos los datos del arma al panel
            PanelArma detallesArma = contenedor.GetComponent<PanelArma>();
            detallesArma.modeloArma = item.arma;
            int nivel = item.lvl;
            detallesArma.precio = item.niveles[nivel].precio;
            detallesArma.t_nombre.text = item.arma.GetComponent<Arma>().nombre;
            detallesArma.t_precio.text = "" + detallesArma.precio;
            detallesArma.t_descripcion.text = "Nuevo Atk : "+item.niveles[nivel].ataque;
            detallesArma.imagenArma.sprite = detallesArma.modeloArma.GetComponent<Arma>().imagenArma;
            detallesArma.codigoArma = item.index;
        }





    }




    public void clickMejora()
    {
        botonMejora.SetActive(false);
        botonTienda.SetActive(true);

        MostrarMejoras();

    }

    public void clickTienda()
    {
        botonMejora.SetActive(true);
        botonTienda.SetActive(false);

        recargar();

    }






}
