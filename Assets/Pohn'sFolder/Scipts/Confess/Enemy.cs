using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            EnemySpwaner.Instance.enemyCount--;
        }
        if (collision.gameObject.tag == "HP")
        {
            EnemySpwaner.Instance.enemyCount--;

            Destroy(gameObject);
        }
    }
}
