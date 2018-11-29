
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    ///////////////////////// Configuracion oleadas //////////////////////////////////////////////////////////////////////

    public float waveTime;          //Tiempo entre una oleada y la siguiente
    public float waveDelay;         //Tiempo de espera al iniciar el piso
    public float bossTime;          //Tiempo entre que se spawnea el boss y pierdes.
    public float maxTime;           //Tiempo total (suma de los anteriores)
    public GameObject[] waves;      //objeto que contiene las oleadas. se activan para que la oleada aparezca
    public GameObject Boss;

    //////////////////////////////  UI//////////////////////////////////////////////////////////////////////////

    public Text startDelayText;
    public Text maxTimeText;
    public Text waveTimeText;
    public Slider waveSlider;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////

     float actualTime;       //Cuenta regresiva del tiempo total
     float actualWaveTime;   //tiempo restante para la siguiente oleada
     float actualDelay;      //Sirve para iniciar la primera oleada 
     int nextWave;          //almacena la siguiente oleada que debe spawnearse 
     bool start;
     int totalWaves;
     bool boss = false;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public PlayerMovment heroe;






	void Start () {
        totalWaves = waves.Length;
        maxTime =  waveTime * totalWaves + bossTime;
        actualWaveTime = 0;
        actualTime = maxTime;
        actualDelay = waveDelay;
        nextWave = 0;
        start = false;

        startDelayText.text = actualDelay.ToString();
        maxTimeText.text = actualTime.ToString();
        waveTimeText.text = waveTime.ToString();
        waveSlider.maxValue = maxTime;
        waveSlider.value = maxTime;
        heroe.enabled = true;


	}

	
	void Update () {
        if (start)
        {
            actualTime -= Time.deltaTime;
            if (actualWaveTime <= 0)
            {
                if (nextWave <= totalWaves - 1)
                {
                    ///aun se pueden spawnear oleadas

                    waves[nextWave].gameObject.SetActive(true);

                    nextWave++;
                    actualWaveTime = waveTime;
                }
                else
                {
                    //se alcanzo la ultima oleada. toca spawnear al boss
                    if (!boss)
                    {
                        boss = true;
                        //invocar boss
                        Boss.SetActive(true);
                        actualWaveTime = bossTime;
                    }
                }
            }
            else
            {
                actualWaveTime -= Time.deltaTime;
            }
            waveTimeText.text = Mathf.Round(actualWaveTime) + "";
            maxTimeText.text = Mathf.Round(actualTime) + "";
            waveSlider.value = actualTime;
        }
        else
        {
            actualDelay -= Time.deltaTime;
            startDelayText.text = Mathf.Round(actualDelay) + "";
            if (actualDelay <= 0)
            {
                start = true;
                startDelayText.enabled = false;
            }
        }
	}
}
