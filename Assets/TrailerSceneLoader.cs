using UnityEngine;
using UnityEngine.SceneManagement;

public class TrailerSceneLoader : MonoBehaviour
{
    public string trailerSceneName = "1"; // Nombre de la escena del tráiler

    // Método para cambiar a la escena del tráiler
    public void LoadTrailerScene()
    {
        if (!string.IsNullOrEmpty(trailerSceneName))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena del tráiler no está configurado.");
        }
    }
}
