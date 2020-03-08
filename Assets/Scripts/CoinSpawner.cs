//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float spawnRate = 2.0f;

    public GameObject Coin;
    public GameObject CoinPositions;
    public GameObject Coins;

    private float tSinceLastSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tSinceLastSpawn += Time.deltaTime;


        if(tSinceLastSpawn > spawnRate)
        {

            tSinceLastSpawn = 0;
            float r = Random.Range(0f, 1f);
            if (r < 0.5)
            {
                foreach (Transform spawn in CoinPositions.gameObject.transform)
                {
                    bool isTooClose = false;
                    foreach (Transform coin in Coins.gameObject.transform)
                    {
                        if (Vector3.Distance(coin.transform.position,spawn.transform.position) < 0.1f)
                        {
                            isTooClose = true;
                        }
                    }
                    if (!isTooClose && Random.Range(0f,1f) % 3 <= 1)
                    {
                        Instantiate(Coin, spawn.transform.position + new Vector3(0,0,100), new Quaternion(), Coins.transform);
                        break;
                    }
                }
            }
        }
    }
}
