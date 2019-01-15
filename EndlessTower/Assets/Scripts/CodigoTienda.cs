using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class CodigoTienda : MonoBehaviour
{
    public GameObject Cambiar1;
    public GameObject Cambiar2;
    public GameObject Boton1;
    public GameObject Boton2;

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
    [Header("-----------------------------------------------------")]
    [Header("Producto#2:")]
    public GameObject armas3;
    public Text D3_nombre;
    public Text D3_precio;
    public GameObject b_Comprar_3;
    public GameObject b_Comprado_3;
    public GameObject imgCompra_3;


    //############################//Producto_1

    public void presionarInformacion_1()
    {
        Arma primeraArma = armas1.GetComponent<Arma>();

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
        Arma segundaArma = armas2.GetComponent<Arma>();

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

    //############################//ProductoMejora_1

    public void presionarInformacionMejora_1()
    {
        Arma primeraM_Arma = armas3.GetComponent<Arma>();

        panel_nombre.text = primeraM_Arma.nombre;

        panel_inf.text = "Elemento: " + primeraM_Arma.elemento + "\n\n"
                        + "Ataque: " + primeraM_Arma.ataque + "\n\n"
                        + "Descripción: " + primeraM_Arma.descripcion;

        panel_Nuevo.SetActive(true);
    }

    public void presionarBoton_3()
    {
        int a3 = (int.Parse(Dinero.text));
        int b3 = (int.Parse(D2_precio.text));
        if (a3 > b3 || a3 == b3)
        {
            imgCompra_3.SetActive(true);
            b_Comprar_3.SetActive(false);
            b_Comprado_3.SetActive(true);
            a3 = a3 - b3;
            Dinero.text = a3.ToString();
        }
        else
        if (a3 < b3)
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

    public void cambiarMejora()
    {
        Boton1.SetActive(false);
        Boton2.SetActive(true);
        Cambiar1.SetActive(false);
        Cambiar2.SetActive(true);
    }

    public void cambiarNuevo()
    {
        Boton2.SetActive(false);
        Boton1.SetActive(true);
        Cambiar2.SetActive(false);
        Cambiar1.SetActive(true);
    }

    void Start()
    {
        //-------------------------------------------------------------------------------
        Arma primeraArma = armas1.GetComponent<Arma>();
        D1_nombre.text = primeraArma.nombre;
        D1_precio.text = primeraArma.precio;
        //-------------------------------------------------------------------------------
        Arma segundaArma = armas2.GetComponent<Arma>();
        D2_nombre.text = segundaArma.nombre;
        D2_precio.text = segundaArma.precio;
        //-------------------------------------------------------------------------------
        Arma primeraM_Arma = armas3.GetComponent<Arma>();
        D3_nombre.text = primeraM_Arma.nombre;
        D3_precio.text = primeraM_Arma.precio;
    }



}
