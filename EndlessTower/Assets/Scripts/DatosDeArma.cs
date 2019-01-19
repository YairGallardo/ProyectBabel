using UnityEngine;
[System.Serializable]
public class DatosDeArma  {
    public GameObject arma;
    public bool activ;
    public int lvl;
    public int index;
    public Especificaciones[] niveles;
}

[System.Serializable]
public class Especificaciones {
    public int ataque;
    public int precio;
}