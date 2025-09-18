using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] private ApplesPool _applesPool;

    [Header("Apples Spawn Settings")]
    [SerializeField] private float _spawnPointRadius = 0.5f;
    [SerializeField] private float _minSpawnTime = 5, _maxSpawnTime = 15;
    [Tooltip("Minimum distance from the center of the trunk to prevent apples from spawning directly above it")]
    [SerializeField] private float _minDistanceFromTrunk = 0.2f;


    private void Awake()
    {
        StartCoroutine(TreeCycle());
    }

    private IEnumerator TreeCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            Apple apple = _applesPool.GetItemFromPool();
            apple.transform.position = GetRandomPointAroundTree(_spawnPointRadius);
            apple.EnableApplePhysics();
        }
    }

    private Vector3 GetRandomPointAroundTree(float radius)
    {
        Vector3 randomPos = Random.insideUnitSphere;
        Vector2 horizontalPos = new Vector2(randomPos.x, randomPos.z);

        if (horizontalPos.magnitude < _minDistanceFromTrunk)
            horizontalPos = horizontalPos.normalized * _minDistanceFromTrunk; // Push the apple away from the center

        randomPos.x = horizontalPos.x;
        randomPos.z = horizontalPos.y;

        return transform.position + randomPos * radius;
    }

}
