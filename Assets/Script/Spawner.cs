using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<AnimalSettings> animals = new List<AnimalSettings>();

    private Terrain terrain;
    private float terrainWidth;
    private float terrainLength;

    private void Start()
    {
        terrain = Terrain.activeTerrain;

        if (terrain)
        {
            terrainWidth = terrain.terrainData.size.x;
            terrainLength = terrain.terrainData.size.z;

            SpawnAnimals();
        }
    }
    private void SpawnAnimals()
    {
        foreach (var animalSetting in animals)
        {
            for(int i = 0; i< animalSetting.spawnCount;  i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                Instantiate(animalSetting.animalPreFab, spawnPosition, Quaternion.identity);
            }
        }
    }
    private Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(0f, terrainWidth);
        float z = Random.Range(0f, terrainLength);
        float y = terrain.SampleHeight(new Vector3(x,0,z));
        return new Vector3(x,y,z);
    }
}

[System.Serializable]
public class AnimalSettings
{
    public GameObject animalPreFab;
    public int spawnCount = 10;
}
