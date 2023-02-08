using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawn;
using static UnityEditor.PlayerSettings;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private SpawnTestSO spawnManagerSO;
    [SerializeField] private SpawnPoint spawnPoint;
    [SerializeField] private string spawnName;

    public void Start()
    {

    }

    public void CreateSpawn(string name, Vector3 position, bool assignSpawn = false, bool sizeIsSpawnRadius = false)
    {
        SpawnPoint newSpawnPoint = spawnManagerSO.CreateSpawn(name, position, sizeIsSpawnRadius);
        if (assignSpawn) SetSpawn(newSpawnPoint);
    }

    public void CreateSpawn(string name, Vector3 position, Vector3 size, bool assignSpawn = false, bool sizeIsSpawnRadius = false)
    {
        SpawnPoint newSpawnPoint = spawnManagerSO.CreateSpawn(name, position, size, sizeIsSpawnRadius);
        if (assignSpawn) SetSpawn(newSpawnPoint);
    }

    public void SetSpawn()
    {
 
    }

    public void SetSpawn(string spawnName)
    {
        spawnManagerSO.spawnPoints.TryGetValue(spawnName, out spawnPoint);
        if (spawnPoint != null)
        {
            spawnPoint.JoinSpawnPoint(gameObject);
            SetSpawn(spawnPoint);
        }
       
    }

    private void SetSpawn(SpawnPoint spawn)
    {

        spawnPoint = spawn; 
        spawnName = spawn.Name; 
    }
    
    public void Spawn()
    {
       transform.position = spawnPoint.GetPosition();
    }


   
}
