using Spawn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOBJ : MonoBehaviour
{
    public SpawnPoint spawnPoint;
    public Vector3 position;
    public Vector3 size;
   [SerializeField] private BoxCollider boxCol;

    private void Start()
    {
 
    }
    public SpawnPoint InitSpawn(string spawnPointName, Vector3 spawnPointPosition, bool sizeIsSpawnRadius)
    {
        spawnPoint = new SpawnPoint(spawnPointName, spawnPointPosition, sizeIsSpawnRadius);
        SetPosition(spawnPointPosition);
        return spawnPoint;
    }

    public SpawnPoint InitSpawn(string spawnPointName, Vector3 spawnPointPosition, Vector3 size, bool sizeIsSpawnRadius)
    {
        spawnPoint = new SpawnPoint(spawnPointName, spawnPointPosition, size, sizeIsSpawnRadius);
        SetPositionAndSize(spawnPointPosition, size);
        return spawnPoint;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
        spawnPoint.SetPosition(position);
        Set();
    }

    public void SetPositionAndSize(Vector3 position, Vector3 size)
    {
        transform.position = position;
        transform.localScale = size;
        spawnPoint.SetPosition(position);
        Set();
    }

    public void Set()
    {
        position = transform.position;
        size = transform.localScale;
        boxCol.size = size;
        Debug.Log(transform.position);

    }
}
