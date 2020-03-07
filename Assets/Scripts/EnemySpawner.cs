using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyA;
    public GameObject enemyB;
    public GameObject player;

    public int enemyTypeCnt;
    public float maxClosestToPlayerSpawnPos;


    private int level;
    private double tSinceLastWave;


    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        tSinceLastWave = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (tSinceLastWave < Mathf.Max(0.3f , (10 - level) * 10) ) {
            float r = Random.Range(0f, 1f);
            // TODO ADD CHANCE LOGIC
            if (r < 0.4) {
                tSinceLastWave = 0;
                // TRY TO SPAWN ENEMY
                // bruteforce
                for (int i = 0; i < 20; i++) {
                    float spawnY = Random.Range
                        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                    float spawnX = Random.Range
                        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

                    Vector2 spawnPosition = new Vector2(spawnX, spawnY);

                    Vector2 playerPosition = (Vector2)player.transform.position;
                    if ( Vector2.Distance(spawnPosition, playerPosition  ) > maxClosestToPlayerSpawnPos )
                    {
                        float rE = Mathf.Floor(Random.Range(0f, enemyTypeCnt));

                        if (rE == 0f)
                        {
                            Instantiate(enemyA, spawnPosition, Quaternion.identity);
                        }
                        else if (rE == 1f)
                        {
                            Instantiate(enemyB, spawnPosition, Quaternion.identity);
                        }
                    }
                }
            }
        }

        tSinceLastWave += Time.deltaTime;

    }
}
