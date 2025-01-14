using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class recogerPuntuacion : MonoBehaviour
{
    private TMP_Text scoreText;
    [SerializeField] private int score = 0;
    public string targetScene = "MAIN";
    // Start is called before the first frame update

    void Start()
    {
        scoreText = GameObject.Find("3DCanvas/window/score").GetComponent<TextMeshProUGUI>();
        score = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Puntuación: " + score;
    }

    public void goTo()
    {
        SceneManager.LoadScene(targetScene);
    }
}
