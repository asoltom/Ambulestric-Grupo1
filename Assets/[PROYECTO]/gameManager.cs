using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI hpText;
    public string targetScene = "Fin_partida";

    private void Start()
    {
        scoreText = GameObject.Find("puntuacion/labelPuntuacion/textPuntuacion").GetComponent<TextMeshProUGUI>();
        hpText = GameObject.Find("vida/labelHp/textHp").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if ((hpText != null) && (scoreText != null))
        {
            int currentHP;
            int currentScore;
            //Recogemos la vida actual
            if (int.TryParse(hpText.text.Replace("HP: ", ""), out currentHP))
            {
                //Comprobamos si es <=0f
                if (currentHP <= 0.0f)
                {
                    //Recogemos la puntuación actual y la guardamos
                    if (int.TryParse(scoreText.text.Replace("Score:", ""), out currentScore))
                    {
                        //Guardar puntuación
                        PlayerPrefs.SetInt("PlayerScore", currentScore);
                        SceneManager.LoadScene(targetScene);

                    }
                    else
                    {
                        Debug.LogError("El texto de Score no es un numero valido");
                    }
                }
            }
            else
            {
                Debug.LogError("El texto de HP no es un numero valido.");
            }
        }
    }
}
