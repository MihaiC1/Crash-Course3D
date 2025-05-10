using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private GameObject[] chunkPrefabs;   // Set of prefab chunks to choose from
    [SerializeField]private int chunksOnScreen = 5;
    [SerializeField]private float chunkLength = 5f;
    [SerializeField]private Transform chunkParent;

    private float spawnZ = 0f;
    private List<GameObject> activeChunks = new List<GameObject>();

    void Start()
    {
        // Spawn initial chunks
        for (int i = 0; i < chunksOnScreen; i++)
        {
            if (i == 0)
                SpawnChunk(0); // First one fixed
            else
                SpawnChunk(Random.Range(0, chunkPrefabs.Length));
        }
    }

    void Update()
    {
        if (player.position.z - 20> spawnZ - chunksOnScreen * chunkLength)
        {

            SpawnChunk(Random.Range(0, chunkPrefabs.Length));
            DeleteOldestChunk();
        }
    }

    void SpawnChunk(int index)
    {
        Vector3 spawnPosition = new Vector3(-2.6f, 0f, spawnZ);
        GameObject go = Instantiate(chunkPrefabs[index], spawnPosition, Quaternion.identity);
        go.transform.SetParent(chunkParent);
        Debug.Log("Test");
        activeChunks.Add(go);
        spawnZ += chunkLength;
    }

    void DeleteOldestChunk()
    {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }
}
