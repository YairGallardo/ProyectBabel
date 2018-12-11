using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="BaseDatos", menuName = "Inventario/Lista",order = 1)]
public class DataBase : ScriptableObject
{
    [System.Serializable]      //Para visualizar
    public struct ObjetoInventario
    {
        public string nombre; //Nombre del Objeto
        public int ID;        //ID del objeto
        public Sprite icono;
                public int precio;  
        public Clase clase;
       public bool acumulable; //NO NECESARIO.
        public string descripcion;
        //internal int clase;
    }

    public enum Clase
    {
        mejora, 
        armanueva
    }

    public ObjetoInventario[] baseDatos;

}
