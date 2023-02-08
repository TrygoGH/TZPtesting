using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
        
    public class SpawnPoint
    {
        public string Name { get; private set; }
        private Vector3 position;
        private Vector3 size;
        private bool sizeIsSpawnRadius;
        public List<GameObject> owners = new List<GameObject>();
           
        public SpawnPoint()
        {
            position = Vector3.zero;
            size = Vector3.one;
        } 

        public SpawnPoint(string spawnPointName, Vector3 spawnPointPosition, bool sizeIsSpawnPointRadius = false)
        {
            Name = spawnPointName;
            position= spawnPointPosition;
            size = Vector3.one;
            sizeIsSpawnRadius = sizeIsSpawnPointRadius;
        }

        public SpawnPoint(string spawnPointName, Vector3 spawnPointPosition, Vector3 spawnPointSize, bool sizeIsSpawnPointRadius = false)
        {
            Name = spawnPointName;
            position = spawnPointPosition;
            size = spawnPointSize;
            sizeIsSpawnRadius = sizeIsSpawnPointRadius;
        }

        public void JoinSpawnPoint(GameObject newOwner)
        {
            owners.Add(newOwner);
        }

        public void SetPosition(Vector3 spawnPointPosition)
        {
            position = spawnPointPosition;
        }

        public Vector3 GetPosition()
        {
            Vector3 spawnPosition;
            return spawnPosition = sizeIsSpawnRadius ? GetSpawnSizePosition() : position;
        }

        private Vector3 GetSpawnSizePosition()
        {
            return CalculateSpawnPosition(position, size);
        }

        private Vector3 CalculateSpawnPosition(Vector3 origin, Vector3 size)
        {
            float xRange = size.x / 2;
            float yRange = size.y / 2;
            float zRange = size.z / 2;
            xRange = Random.Range(-xRange, xRange);
            yRange = Random.Range(-yRange, yRange);
            zRange = Random.Range(-zRange, zRange);
            return new Vector3(xRange, yRange, zRange);
        }
    }

}