using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class confirmarCompra : MonoBehaviour
{
    [SerializeField]
    ShopManager tienda;
    public Slider slider;
    public Text CantidadText;
    public bool copra = true;
    public bool compra = true;
    public int id;
    GameObject cartelConf;

    void Start()
    {
        cartelConf = tienda.confCompra;
    }

    void Update()
    {
        //24:00 en el VIDEOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!
    }

}