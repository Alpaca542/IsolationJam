using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject MotherBoat;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(Enemies[Random.Range(0, Enemies.Length)], new Vector2(Random.Range(MotherBoat.transform.position.x - 10f, MotherBoat.transform.position.x + 10f), Random.Range(MotherBoat.transform.position.y - 10f, MotherBoat.transform.position.y + 10f)), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
