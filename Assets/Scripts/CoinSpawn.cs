using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform spawnPoint;
    private float timer;
    private float cooldown;
    public float minCooldown;
    public float maxCooldown;

    private void Update()
    {
        timer += Time.deltaTime;
        cooldown = Random.Range(minCooldown, maxCooldown);
        if(timer > cooldown)
        {
            StartCoroutine(SpawnCoins());
            timer = 0;
        }
    }

    IEnumerator SpawnCoins()
    {
        for (int i = 0; i < Random.Range(1, 6); i++)
        {
            int a = Random.Range(0, 2);
            float spawnX = 0;
            if(a == 1)
            {
                spawnX = -2.5f;
            }
            else
            {
                spawnX = 2.5f;
            }
            GameObject spawnedCoin = Instantiate(coinPrefab, new Vector3(spawnX, -0.5f, spawnPoint.position.z), Quaternion.identity);
            spawnedCoin.transform.SetParent(null);
            yield return new WaitForSeconds(1f);
        }
    }
}
