using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public PlayerController player;
    public List<Transform> patrolPonts;
    private int enimesMaxCount = 5;
    private float delay = 2.5f;
    private float increaseEnemyCountDelay = 30;

    private List<Transform> _spawnerPoints;
    private List<EnemyAI> _enemies;

    private float _timeLastSpawned;
    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAI>();
        Invoke("IncreaseEnimesMaxCount", increaseEnemyCountDelay);
    }

    private void Update()
    {
        CheckForDeadEnimies();
        CreateEnemy();
    }


    private void IncreaseEnimesMaxCount()
    {
        enimesMaxCount++;
        Invoke("IncreaseEnimesMaxCount", increaseEnemyCountDelay);
    }
    private void CheckForDeadEnimies()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }
    }

    private void CreateEnemy()
    {
        if (_enemies.Count >= enimesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return;

        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;

        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
        enemy.player = player;
        enemy.patrolPonts = patrolPonts;
    }
}

