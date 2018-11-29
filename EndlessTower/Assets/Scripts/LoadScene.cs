
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {

  public void clickar() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("click");
    }
}
