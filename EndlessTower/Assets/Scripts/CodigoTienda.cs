using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class CodigoTienda : MonoBehaviour
{
    public GameObject b_Alerta;
    public GameObject b_Aceptar;
    public Text Dinero;
    public GameObject panel_Nuevo;
    public Text panel_nombre;
    public Text panel_inf;
    [Header("Producto#1:")]
    public GameObject armas1;
    public Text D1_nombre;
    public Text D1_precio;
    public GameObject b_Comprar_1;
    public GameObject b_Comprado_1;
    public GameObject imgCompra_1;
    //public Text Dinero2_1;
    //public GameObject b_Informacion_1;
    [Header("-----------------------------------------------------")]
    [Header("Producto#2:")]
    public GameObject armas2;
    public Text D2_nombre;
    public Text D2_precio;
    public GameObject b_Comprar_2;
    public GameObject b_Comprado_2;
    public GameObject imgCompra_2;
    //public Text Dinero2_2;
   //public GameObject b_Informacion_2;



    //############################//Producto_1

    public void presionarInformacion_1()
    {
        Arma_Tienda primeraArma = armas1.GetComponent<Arma_Tienda>();

        panel_nombre.text = primeraArma.nombre;

        panel_inf.text = "Elemento: " + primeraArma.elemento+ "\n\n"
                        + "Ataque: " + primeraArma.ataque + "\n\n"
                        + "Descripción: " + primeraArma.descripcion;

        panel_Nuevo.SetActive(true);
    }

    public void presionarBoton_1()
    {
        int a = (int.Parse(Dinero.text));
        int b = (int.Parse(D1_precio.text));
        if (a > b || a == b)
        {
            imgCompra_1.SetActive(true);
            b_Comprar_1.SetActive(false);
            b_Comprado_1.SetActive(true);
            a = a - b;
            Dinero.text = a.ToString();
        }
        else
        if (a < b)
        {
            b_Alerta.SetActive(true);
 
        }
    }

    //############################//Producto_2

    public void presionarInformacion_2()
    {
        Arma_Tienda segundaArma = armas2.GetComponent<Arma_Tienda>();

        panel_nombre.text = segundaArma.nombre;

        panel_inf.text = "Elemento: " + segundaArma.elemento + "\n\n"
                        + "Ataque: " + segundaArma.ataque + "\n\n"
                        + "Descripción: " + segundaArma.descripcion;

        panel_Nuevo.SetActive(true);
    }

    public void presionarBoton_2()
    {
        int a2 = (int.Parse(Dinero.text));
        int b2 = (int.Parse(D2_precio.text));
        if (a2 > b2 || a2 == b2)
        {
            imgCompra_2.SetActive(true);
            b_Comprar_2.SetActive(false);
            b_Comprado_2.SetActive(true);
            a2 = a2 - b2;
            Dinero.text = a2.ToString();
        }
        else
        if (a2 < b2)
        {
            b_Alerta.SetActive(true);
        }
    }

    //############################//
    public void presionarAceptar()
    {
        b_Alerta.SetActive(false);
    }

    public void presionarAceptarEnInformacion()
    {
        panel_Nuevo.SetActive(false);
    }

    void Start()
    {
        //-------------------------------------------------------------------------------
        Arma_Tienda primeraArma = armas1.GetComponent<Arma_Tienda>();
        D1_nombre.text = primeraArma.nombre;
        D1_precio.text = primeraArma.precio;
        //-------------------------------------------------------------------------------
        Arma_Tienda segundaArma = armas2.GetComponent<Arma_Tienda>();
        D2_nombre.text = segundaArma.nombre;
        D2_precio.text = segundaArma.precio;
    }



}
