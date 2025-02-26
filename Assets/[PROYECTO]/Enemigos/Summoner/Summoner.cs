using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Summoner : MonoBehaviour
{
    public GameObject prefabRedEnemy;
    public GameObject prefabBlueEnemy;
    public GameObject prefabYellowEnemy;

    public float minTiempo = 0.75f;
    public float maxTiempo = 2.0f;
    private float[] fuerza_lanzada = new float[3] {0.1f, 1.5f, 3f};

    private void Start()
    {
        StartCoroutine(ISummoner());
    }

    IEnumerator ISummoner() 
    {
        GameObject[] enemies = new GameObject[3] { prefabBlueEnemy, prefabRedEnemy, prefabYellowEnemy };
        while (true) 
        {
            GameObject attack = Instantiate(enemies[Random.Range(0, 3)], this.transform.position + transform.right * 0.1f, this.transform.rotation);

            attack.GetComponent<Rigidbody>().velocity = transform.forward * fuerza_lanzada[Random.Range(0, 3)];
            yield return new WaitForSeconds(Random.Range(minTiempo, maxTiempo));
        }
    }
}
