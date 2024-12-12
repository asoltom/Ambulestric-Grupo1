using UnityEngine;
using UnityEngine.SceneManagement;

public class TrailerSceneLoader : MonoBehaviour
{
    public string trailerSceneName = "1"; // Nombre de la escena del tr�iler

    // M�todo para cambiar a la escena del tr�iler
    public void LoadTrailerScene()
    {
        if (!string.IsNullOrEmpty(trailerSceneName))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena del tr�iler no est� configurado.");
        }
    }
}
