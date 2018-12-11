using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour
{
    public int money=200;

    public GameObject Player;
    public GameObject Inv;
    [SerializeField]
    private List<ItemTienda> ItemCompra;
    private List<ItemTienda> itDesactivar = new List<ItemTienda>();
    private List<ItemTienda> itActivar = new List<ItemTienda>();
    private List<ItemTienda> ItemVendidos = new List<ItemTienda>(); //Item Vendido vendiendolo ... NO NECESARIO
    [SerializeField]

    private DataBase DB;
    public GameObject ContenedorItem;

    [Header("Carteles")]

    public Text cartelMoney;
    public GameObject insuficienteDinero;
    public GameObject confCompra;
    public GameObject compraMas;

    // Use this for initialization
    void Start ()
    {
        //LLENAR LA LISTA COMPRA
        ItemCompra = new List<ItemTienda>();                    
        for (int i = 0; i < ContenedorItem.transform.childCount; i++) //Encargado de contar el contenedor items o numero de hijos
        {
            ItemCompra.Add(ContenedorItem.transform.GetChild(i).GetComponent<ItemTienda>()); //agrega al contenedor item a los hijos
        }
        confCompra.SetActive(false);
        compraMas.SetActive(false);
        insuficienteDinero.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        cartelMoney.text = "Monedas: " + money;
	}

    public void ComprarItem(int ItemID, int Cantidad)
    {
        if (money >= ItemCompra[ItemID].precio * Cantidad)
        {

            Debug.Log("ItemTienda Comprado");

            money -= ItemCompra[ItemID].precio * Cantidad;
            //AGREGAS ITEM DE TU INVENTARIO
            if (ItemCompra[ItemID].acumulable)
            {
                //Inv.GetComponent<InventarioNuevo>().AgregarItem(ItemID, Cantidad);
            }
            else
            {
                for (int item = 0; item < Cantidad; item++)
                {
                   // Inv.GetComponent<InventarioNuevo>().AgregarItem(ItemID, 1);
                }
            }
            ItemCompra[ItemID].Cantidad -= Cantidad;
        }
        else
        {
            insuficienteDinero.SetActive(true);
        }
    }

}
