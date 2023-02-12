using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : Singleton<EnemySpwaner>
{
    public int enemyCount;
    public int maxCount;
    public float timer;
    public float spwanTime;
    public float curTime;
    [SerializeField]
    private GameObject enemy;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        timer -= Time.deltaTime;
        Uimanager.Instance.timer = timer;
        Uimanager.Instance.count = enemyCount;
        if (curTime >= spwanTime&&timer>0)
        {
            int x = Random.Range(0, spawnPoints.Length);
            int y = Random.Range(0, spawnPoints.Length);
            SpawnEnemy(y);
            SpawnEnemy(x);
        }
        curTime += Time.deltaTime;
    }
    public void SpawnEnemy(int ranNum)
    {
        curTime = 0;
        enemyCount++;
        Instantiate(enemy, spawnPoints[ranNum]);
    }

}
