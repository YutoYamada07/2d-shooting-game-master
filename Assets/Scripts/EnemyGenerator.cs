using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject BossEnemyPrefab;

    private int random;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, 0.7f);
        Invoke("BossSpawn", 12f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        Vector3 spawnPositon = new Vector3(
            Random.Range(-2.9f, 2.9f),
            transform.position.y,
            transform.position.z);

        Instantiate(enemyPrefab, spawnPositon, transform.rotation);
    }

    void BossSpawn()
    {
        Instantiate(BossEnemyPrefab, transform.position, transform.rotation);
        CancelInvoke();
    }
}
