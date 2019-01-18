
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class CodigoTiendaMejora : MonoBehaviour
{
    public GameObject b_Alerta;
    public GameObject b_Aceptar;
    public Text Dinero;
    [Header("Producto#1:")]
    public GameObject armas1;
    public Text D1_nombre;
    public Text D1_precio;
    public Text D1_descripcion;
    public GameObject b_Comprar_1;
    public GameObject b_Comprado_1;
    public Image imagenArma1;
    String dineroMuestra1 = "0";
    [Header("-----------------------------------------------------")]
    [Header("Producto#2:")]
    public GameObject armas2;
    public Text D2_nombre;
    public Text D2_precio;
    public Text D2_descripcion;
    public GameObject b_Comprar_2;
    public GameObject b_Comprado_2;
    public Image imagenArma2;
    String dineroMuestra2 = "0";
    [Header("-----------------------------------------------------")]
    [Header("Producto#3:")]
    public GameObject armas3;
    public Text D3_nombre;
    public Text D3_precio;
    public Text D3_descripcion;
    public GameObject b_Comprar_3;
    public GameObject b_Comprado_3;
    public Image imagenArma3;
    String dineroMuestra3 = "0";
    [Header("-----------------------------------------------------")]
    [Header("Producto#4:")]
    public GameObject armas4;
    public Text D4_nombre;
    public Text D4_precio;
    public Text D4_descripcion;
    public GameObject b_Comprar_4;
    public GameObject b_Comprado_4;
    public Image imagenArma4;
    String dineroMuestra4 = "0";
    [Header("-----------------------------------------------------")]
    [Header("Producto#5:")]
    public GameObject armas5;
    public Text D5_nombre;
    public Text D5_precio;
    public Text D5_descripcion;
    public GameObject b_Comprar_5;
    public GameObject b_Comprado_5;
    public Image imagenArma5;
    String dineroMuestra5 = "0";

    //############################//Producto_1
    public void presionarInformacion_1()
    {
        Arma primeraArma = armas1.GetComponent<Arma>();
        armas1.SetActive(true);
    }
    public void presionarBoton_1()
    {
        int a = (int.Parse(Dinero.text));
        int b = (int.Parse(dineroMuestra1));
        if (a > b || a == b)
        {
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
        armas2.SetActive(true);
    }
    public void presionarBoton_2()
    {
        int a = (int.Parse(Dinero.text));
        int b = (int.Parse(dineroMuestra2));
        if (a > b || a == b)
        {
            b_Comprar_2.SetActive(false);
            b_Comprado_2.SetActive(true);
            a = a - b;
            Dinero.text = a.ToString();
        }
        else
        if (a < b)
        {
            b_Alerta.SetActive(true);
        }
    }
    //############################//Producto_3
    public void presionarInformacion_3()
    {
        Arma terceroArma = armas3.GetComponent<Arma>();
        armas3.SetActive(true);
    }
    public void presionarBoton_3()
    {
        int a = (int.Parse(Dinero.text));
        int b = (int.Parse(dineroMuestra3));
        if (a > b || a == b)
        {
            b_Comprar_3.SetActive(false);
            b_Comprado_3.SetActive(true);
            a = a - b;
            Dinero.text = a.ToString();
        }
        else
        if (a < b)
        {
            b_Alerta.SetActive(true);
        }
    }
    //############################//Producto_4
    public void presionarInformacion_4()
    {
        Arma cuartoArma = armas4.GetComponent<Arma>();
        armas4.SetActive(true);
    }
    public void presionarBoton_4()
    {
        int a = (int.Parse(Dinero.text));
        int b = (int.Parse(dineroMuestra4));
        if (a > b || a == b)
        {
            b_Comprar_4.SetActive(false);
            b_Comprado_4.SetActive(true);
            a = a - b;
            Dinero.text = a.ToString();
        }
        else
        if (a < b)
        {
            b_Alerta.SetActive(true);
        }
    }
    //############################//Producto_5
    public void presionarInformacion_5()
    {
        Arma quintoArma = armas5.GetComponent<Arma>();
        armas5.SetActive(true);
    }
    public void presionarBoton_5()
    {
        int a = (int.Parse(Dinero.text));
        int b = (int.Parse(dineroMuestra5));
        if (a > b || a == b)
        {
            b_Comprar_5.SetActive(false);
            b_Comprado_5.SetActive(true);
            a = a - b;
            Dinero.text = a.ToString();
        }
        else
        if (a < b)
        {
            b_Alerta.SetActive(true);
        }
    }
    //############################//
    public void presionarAceptar()
    {
        b_Alerta.SetActive(false);
    }

    void Start()
    {

        //-------------------------------------------------------------------------------
        Arma primeraArma = armas1.GetComponent<Arma>();
        D1_nombre.text = primeraArma.nombre;
        D1_descripcion.text = "Atk: " + primeraArma.ataque + "\n"
                             + "Elem: " + primeraArma.elemento;
        D1_precio.text = "$" + primeraArma.precio;
        dineroMuestra1 = primeraArma.precio;
        imagenArma1.sprite = primeraArma.imagenArma;
        //-------------------------------------------------------------------------------
        Arma segundoArma = armas2.GetComponent<Arma>();
        D2_nombre.text = segundoArma.nombre;
        D2_descripcion.text = "Atk: " + segundoArma.ataque + "\n"
                             + "Elem: " + segundoArma.elemento;
        D2_precio.text = "$" + segundoArma.precio;
        dineroMuestra2 = segundoArma.precio;
        imagenArma2.sprite = segundoArma.imagenArma;
        //-------------------------------------------------------------------------------
        Arma terceroArma = armas3.GetComponent<Arma>();
        D3_nombre.text = terceroArma.nombre;
        D3_descripcion.text = "Atk: " + terceroArma.ataque + "\n"
                             + "Elem: " + terceroArma.elemento;
        D3_precio.text = "$" + terceroArma.precio;
        dineroMuestra3 = terceroArma.precio;
        imagenArma3.sprite = terceroArma.imagenArma;
        //-------------------------------------------------------------------------------
        Arma cuartoArma = armas4.GetComponent<Arma>();
        D4_nombre.text = cuartoArma.nombre;
        D4_descripcion.text = "Atk: " + cuartoArma.ataque + "\n"
                             + "Elem: " + cuartoArma.elemento;
        D4_precio.text = "$" + cuartoArma.precio;
        dineroMuestra4 = cuartoArma.precio;
        imagenArma4.sprite = cuartoArma.imagenArma;
        //-------------------------------------------------------------------------------
        Arma quintoArma = armas5.GetComponent<Arma>();
        D5_nombre.text = quintoArma.nombre;
        D5_descripcion.text = "Atk: " + quintoArma.ataque + "\n"
                             + "Elem: " + quintoArma.elemento;
        D5_precio.text = "$" + quintoArma.precio;
        dineroMuestra5 = quintoArma.precio;
        imagenArma5.sprite = quintoArma.imagenArma;
    }



}

