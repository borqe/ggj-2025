using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private int enemyCount = 100;

    private List<GameObject> pool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), 0), Quaternion.identity);
            pool.Add(enemy);
        }

        Enemy.OnDeath += OnEnemyDeath;
    }
    
    private void OnDestroy()
    {
        Enemy.OnDeath -= OnEnemyDeath;
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemy.transform.position = new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), 0);
        enemy.transform.rotation = Quaternion.identity;
        
        enemy.Activate();
    }
}
