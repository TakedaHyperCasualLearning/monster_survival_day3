using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnComponent : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private float spawnInterval = 0.0f;
    private float spawnTimer = 0.0f;
    [SerializeField] Vector3 spawnPositionOffset = Vector3.zero;

    public GameObject EnemyPrefab { set => enemyPrefab = value; get => enemyPrefab; }
    public float SpawnInterval { set => spawnInterval = value; get => spawnInterval; }
    public float SpawnTimer { set => spawnTimer = value; get => spawnTimer; }
    public Vector3 SpawnPositionOffset { set => spawnPositionOffset = value; get => spawnPositionOffset; }
}
