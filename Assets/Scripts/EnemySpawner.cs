using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;

    public float maxClosestToPlayerSpawnPos;


    private int level;
    private double tSinceLastWave;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        level = 1;
        tSinceLastWave = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (tSinceLastWave > Mathf.Max(1.3f , (5.0f - level) * 5.0f) ) {
            float r = Random.Range(0f, 1f);
            tSinceLastWave = 0;
            // TODO ADD CHANCE LOGIC
            if (r < 0.4) {
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
                        int rE = Random.Range(0, enemies.Length - 1);

                        Instantiate(enemies[rE], spawnPosition, Quaternion.identity);

                    }
                }
            }
        }

        tSinceLastWave += Time.deltaTime;

    }
}
