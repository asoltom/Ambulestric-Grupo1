using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int ScoreSuma = 10;

    public Vector3 movement;
    private GameObject enemy;
    public GameObject paciente;

    public float speed = 0.5f;

    private void Start()
    {
        enemy = this.gameObject;
    }

    private void Update()
    {

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
                    Debug.LogError("El texto de Score no es un número válido");
                }
            }
            //Destruyete
            Destroy(gameObject);
        }
    }
}
