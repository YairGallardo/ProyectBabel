using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public struct ObjetoInventario
    {
        public string nombre;
        public int ID;
        public Sprite icono;
        public int precioVenta;
        public Clase clase;
        public Tipo tipo;
        public bool acumulable;
        public string descripcion;
        public string Void;
    }

    public enum Clase
    {
        ArmaNueva, Mejora
    }

    public enum Tipo
    {
        consumible,
        equipable
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
