using Spawn;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using System;

[CreateAssetMenu]
[System.Serializable]
public class SpawnTestSO : ScriptableObject
{
    public readonly Vector3 defaultSize = Vector3.one;
    public PrefabData prefabData;
    public Dictionary<string, SpawnPoint> spawnPoints = new Dictionary<string, SpawnPoint>();

    

    public SpawnPoint CreateSpawn(string name, Vector3 position, bool sizeIsSpawnPosition)
    {
        Debug.Log("Creating object");
        GameObject spawn = Instantiate(prefabData.spawnPrefab);
        SpawnOBJ spawnPointObject = spawn.GetComponent<SpawnOBJ>();
        SpawnPoint spawnPoint = spawnPointObject.InitSpawn(name, position, sizeIsSpawnPosition);
        return spawnPoint;  
    }

    public SpawnPoint CreateSpawn(string name, Vector3 position, Vector3 size, bool sizeIsSpawnPosition)
    {
        Debug.Log("Creating object");
        GameObject spawn = Instantiate(prefabData.spawnPrefab);
        SpawnOBJ spawnPointObject = spawn.GetComponent<SpawnOBJ>();
        SpawnPoint spawnPoint = spawnPointObject.InitSpawn(name, position, size, sizeIsSpawnPosition);
        return spawnPoint;
    }
}


