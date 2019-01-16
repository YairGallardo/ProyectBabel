using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ControladorBaseDeArmas : MonoBehaviour {
    public static ControladorBaseDeArmas datosPers;

    public  DatosDeArma[] armas;

    private void Awake(){
        if (datosPers == null){
            datosPers = this;
            DontDestroyOnLoad(gameObject);
            cargaInicial();
        }else {
            Destroy(gameObject);
        }
    }

    public GameObject[] getCompradas() {
        int cantArmas = 0;
        foreach (DatosDeArma datos in armas) {
            if (datos.activ) {
                cantArmas++;
            }
        }
        Debug.Log(cantArmas);
        GameObject[] retorno = new GameObject[cantArmas];
        int index = 0;
        foreach (DatosDeArma datos in armas){
            Debug.Log("index "+index);
            if (datos.activ){
                retorno[index] = datos.arma;
                index++;
                Debug.Log("agregado");
            }
        }
        return retorno;
    }

    public void Actualizar(int index) {
        /// actualiza el nivel actual del arma y sus estadisticas
    }

    public void guardar() {
        
    }

    public void cargar() {

    }

    public void cargaInicial() {
        for (int i =0; i< armas.Length; i++) {
            Arma dataArma = armas[i].arma.GetComponent<Arma>();
            int nivel = armas[i].lvl;
            Especificaciones[] niveles = armas[i].niveles;
            int ataque = niveles[nivel - 1].ataque;
            dataArma.ataque = ataque;
        }
    }
    




    
}
