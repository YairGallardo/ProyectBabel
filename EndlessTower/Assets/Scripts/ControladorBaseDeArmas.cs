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

    public DatosDeArma[] getEnVenta()
    {
        int cantArmas = 0;
        foreach (DatosDeArma datos in armas)
        {
            if (!datos.activ)
            {
                cantArmas++;
            }
        }
        Debug.Log(cantArmas);
        DatosDeArma[] retorno = new DatosDeArma[cantArmas];
        int index = 0;
        foreach (DatosDeArma datos in armas)
        {
            Debug.Log("index " + index);
            if (!datos.activ)
            {
                retorno[index] = datos;
                index++;
                Debug.Log("agregado");
            }
        }
        return retorno;
    }

    public DatosDeArma[] getMejoras()
    {
        int cantArmas = 0;
        foreach (DatosDeArma datos in armas)
        {
            if (datos.activ && datos.lvl<10)
            {
                cantArmas++;
            }
        }
        Debug.Log(cantArmas);
        DatosDeArma[] retorno = new DatosDeArma[cantArmas];
        int index = 0;
        foreach (DatosDeArma datos in armas)
        {
            Debug.Log("index " + index);
            if (datos.activ && datos.lvl < 10)
            {
                retorno[index] = datos;
                index++;
            }
        }
        return retorno;
    }






    public void Actualizar(int index)
    {
        armas[index].activ = true;
        guardar();
    }


    public void ActualizarNivel(int index)
    {
        armas[index].lvl += 1;
        Arma dataArma = armas[index].arma.GetComponent<Arma>();
        Especificaciones[] niveles = armas[index].niveles;
        int ataque = niveles[armas[index].lvl - 1].ataque;
        dataArma.ataque = ataque;

        guardar();
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


    public void guardar()
    {

    }

    public void cargar()
    {

    }





}
