using UnityEngine;
using UnityEngine.SceneManagement;
public class JumpScene : MonoBehaviour
{
    //要跳转的场景
    public string scene_name = "SampleScene";
    public void setScene() {
        SceneManager.LoadSceneAsync(scene_name);
    }
}