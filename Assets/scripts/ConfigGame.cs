using UnityEngine;
using UnityEngine.SceneManagement;
public class  ConfigGame : MonoBehaviour
{
    public string targetScene = "clinic";
    public void setExitGame() {
        Application.Quit();
    }
    public void goTo(){
        SceneManager.LoadScene(targetScene);
    }
}