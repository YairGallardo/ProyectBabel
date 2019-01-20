using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelArma : MonoBehaviour
{
    public GameObject modeloArma;
    public int precio;
    public Text t_nombre;
    public Text t_precio;
    public Text t_descripcion;
    public GameObject b_Comprar;
    public GameObject b_Comprado;
    public Image imagenArma;
    public int codigoArma;

    public void comprarArma()
    {
        if (DatosPersistentes.dinero >= precio)
        {
            DatosPersistentes.dinero -= precio;
            ControladorBaseDeArmas DB = FindObjectOfType<ControladorBaseDeArmas>();
            DB.Actualizar(codigoArma);
            TiendaGeneral tienda = FindObjectOfType<TiendaGeneral>();
            tienda.recargar();
        }
        else
        {

            TiendaGeneral tienda = FindObjectOfType<TiendaGeneral>();
            tienda.mensajeError.SetActive(true);
        }


        //CargaDeDatos.Guardar();


    }


    public void comprarMejora()
    {
        if (DatosPersistentes.dinero >= precio)
        {
            DatosPersistentes.dinero -= precio;
            ControladorBaseDeArmas DB = FindObjectOfType<ControladorBaseDeArmas>();
            DB.ActualizarNivel(codigoArma);
            TiendaGeneral tienda = FindObjectOfType<TiendaGeneral>();
            tienda.MostrarMejoras();
        }
        else
        {

            TiendaGeneral tienda = FindObjectOfType<TiendaGeneral>();
            tienda.mensajeError.SetActive(true);
        }
        //CargaDeDatos.Guardar();
    }










}
