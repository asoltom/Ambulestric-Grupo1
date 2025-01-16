using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerManager : MonoBehaviour
{
    public List<GameObject> summoners;
    public float intervaloPrimero = 5f;        // Intervalo para el primer objeto
    public float intervaloSiguientes = 10f;   // Intervalo para los siguientes objetos

    private int indiceActual = 0;             // Índice del objeto actual
    private bool activando = false;           // Controla si el proceso está en curso

    public GameObject VentanaCerrada;
    public GameObject VentanaAbierta;

    void Start()
    {
        // Desactivamos todos los objetos al inicio
        foreach (GameObject obj in summoners)
        {
            obj.SetActive(false);
        }

        // Iniciamos la primera ronda
        StartCoroutine(Ronda1());
    }

    IEnumerator Ronda1()
    {
        Debug.Log("----Ronda1----");
        // Activamos el primer objeto
        if (summoners.Count > 0)
        {
            summoners[0].SetActive(true);
            yield return new WaitForSeconds(intervaloPrimero);
        }
        else
        {
            for (int i = 1; i < summoners.Count; i++)
            {
                summoners[i].SetActive(true);
                yield return new WaitForSeconds(intervaloSiguientes);
            }
        }

        // Pasamos a la siguiente ronda
        StartCoroutine(Ronda2());
    }

    IEnumerator Ronda2()
    {
        Debug.Log("----Ronda2----");
        // Activamos el siguiente
        
        summoners[1].SetActive(true);
        yield return new WaitForSeconds(intervaloSiguientes);

        StartCoroutine(Ronda3());
    }

    IEnumerator Ronda3()
    {
        Debug.Log("----Ronda3----");
        //Abrir ventana
        VentanaCerrada.SetActive(false);
        VentanaAbierta.SetActive(true);

        // Activamos el siguiente
        
        summoners[2].SetActive(true);
        yield return new WaitForSeconds(intervaloSiguientes);

        //StartCoroutine(RondaDescanso());
    }

    IEnumerator RondaDescanso()
    {
        // Ronda de descanso

        // Desactivamos los siguientes objetos uno por uno
        for (int i = 1; i < summoners.Count; i++)
        {
            summoners[i].SetActive(false);
        }

        yield return new WaitForSeconds(intervaloPrimero);

        StartCoroutine(Ronda4());
        
    }

    IEnumerator Ronda4()
    {
        summoners[0].SetActive(true);
        // Se elige alazar desde qué ronda empezar

        int ronda = Random.Range(0, 2);
        if (ronda == 0) { StartCoroutine(Ronda2()); }
        else if (ronda == 1) { StartCoroutine(Ronda3()); }
        else
        {
            Debug.Log("Hubo un error inesperado.");
            Debug.Log("Reiniciando desde Ronda 2.");
            StartCoroutine(Ronda2());
        }
        yield return null;
    }
}
