using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ControladorCargaDeDatos: MonoBehaviour {

    public string nombre = "Test";

    public int dinero;
    public int pisoMaximo;
    public int vida = 100;
    public string codigoArmaActual;
    public GameObject arma;

    ControladorBD cBD;

    void Start() {
        cBD = new ControladorBD();
        ObtenerDatos();
    }

    public void ObtenerDatos() {
        string[] datos = cBD.obtenerDatosInicio();
        dinero = int.Parse(datos[1]);
        pisoMaximo = int.Parse(datos[2]);
        codigoArmaActual = datos[3];
        //carga
        DatosPersistentes.vida = vida;
        DatosPersistentes.dinero = dinero;
        DatosPersistentes.pisoMaximo = pisoMaximo;

        obtenerArma(codigoArmaActual);

        Arma armaDetalle = arma.GetComponent<Arma>();
        armaDetalle.ataque = int.Parse(datos[4]);
        armaDetalle.probEfecto = int.Parse(datos[5]);
        armaDetalle.elemento = datos[6];

        DatosPersistentes.arma = arma;
    }

    void obtenerArma(string codigo) {
        //busca el prefab con el codigo entregado para cargarlo.
        arma = Resources.Load(DatosPersistentes.rutaArmasPrefs+"/"+codigo) as GameObject;
        
    }



}
