
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuButtons : MonoBehaviour {


    public string mainMenu;
    public string nextFloor;


    public GameObject pauseMenu;
    public GameObject deadMenu;
    public GameObject winMenu;




    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Abandonar()
    {
        SceneManager.LoadScene(mainMenu);
    }




    public void siguiente()
    {
        SceneManager.LoadScene(nextFloor);
    }

    public void salir()
    {
        
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
    }

    public void continuar()
    {
        pauseMenu.SetActive(false);
    }
}



