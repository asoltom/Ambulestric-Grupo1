using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI hpText;
    public int ScoreSuma = 10;
    public int HPresta = 10;

    public Vector3 movement;
    private GameObject enemy;
    public GameObject paciente;

    public float speed = 0.025f;

    private void Start()
    {
        enemy = this.gameObject;
        scoreText = GameObject.Find("puntuacion/labelPuntuacion/textPuntuacion").GetComponent<TextMeshProUGUI>();
        hpText = GameObject.Find("vida/labelHp/textHp").GetComponent<TextMeshProUGUI>();

        mirarPaciente();
    }

    private void mirarPaciente()
    {
        GameObject paciente = GameObject.FindWithTag("paciente");
        if (paciente != null)
        {
            // Haz que el enemigo mire hacia el paciente
            enemy.transform.LookAt(paciente.transform);
        }
        else
        {
            Debug.LogError("El objeto paciente no está asignado.");
        }
    }

    private void Update()
    {
        //Moverse
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, paciente.transform.position, speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Verifica si el obeto tiene la etiqueta "arma" o "Projectile"
        if ((collision.gameObject.CompareTag("arma")) || (collision.gameObject.CompareTag("Projectile"))) 
        {
            //Haz algo
            Debug.Log("Enemigo destruido");

            if (scoreText != null) 
            {
                int currentScore;
                if (int.TryParse(scoreText.text.Replace("Score:", ""), out currentScore))
                {
                    currentScore += ScoreSuma;
                    scoreText.text = ""+currentScore;
                }
                else 
                {
                    Debug.LogError("El texto de Score no es un numero valido");
                }
            }
            //Destruyete
            Destroy(gameObject);
        }

        // Si el enemigo toca al paciente
        if(collision.gameObject.CompareTag("paciente"))
        {
            // Actualiza el texto del HP
            if (hpText != null)
            {
                int currentHP;
                if (int.TryParse(hpText.text.Replace("HP: ", ""), out currentHP))
                {
                    currentHP -= HPresta;
                    hpText.text = "" + currentHP;
                }
                else
                {
                    Debug.LogError("El texto de HP no es un numero valido.");
                }
            }
            //Destruyete
            Destroy(gameObject);
        }
    }
}
