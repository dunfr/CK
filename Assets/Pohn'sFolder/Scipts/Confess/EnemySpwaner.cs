using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public int enemyCount;
    public int maxCount;
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
        if (curTime >= spwanTime&&enemyCount<maxCount)
        {
            int x = Random.Range(0, spawnPoints.Length);
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
