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
    //############################//Producto_1
    public GameObject b_Comprar_1;
    public GameObject b_Comprado_1;
    public Image imgCompra_1;

    public Text Dinero2_1;
    public void presionarBoton_1()
    {
        int a = (int.Parse(Dinero.text));
        int b = (int.Parse(Dinero2_1.text));
        if (a > b || a == b)
        {
            imgCompra_1.enabled = true;
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
    public GameObject b_Comprar_2;
    public GameObject b_Comprado_2;
    public Image imgCompra_2;
    public Text Dinero2_2;

    public void presionarBoton_2()
    {
        int a2 = (int.Parse(Dinero.text));
        int b2 = (int.Parse(Dinero2_2.text));
        if (a2 > b2 || a2 == b2)
        {
            imgCompra_2.enabled = true;
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
    //############################//Producto_3
    public GameObject b_Comprar_3;
    public GameObject b_Comprado_3;
    public Image imgCompra_3;
    public Text Dinero2_3;

    public void presionarBoton_3()
    {
        int a3 = (int.Parse(Dinero.text));
        int b3 = (int.Parse(Dinero2_3.text));
        if (a3 > b3 || a3 == b3)
        {
            imgCompra_3.enabled = true;
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
}
