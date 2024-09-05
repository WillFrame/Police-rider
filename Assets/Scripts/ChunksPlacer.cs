using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    public Transform PoliceCar; // Player  у типа
    public Chunk[] ChunkPrefabs; //тк он так назавал какие-то перфабы
    public Chunk FirstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }

    private void Update()
    {
            /*Player*/ 
        if (PoliceCar.position.z > spawnedChunks[spawnedChunks.Count - 1].End.position.z - 15)
        {
            SpawnChunk();
        }
        // Удаление чанков, которые находятся слишком далеко позади игрока
        if (spawnedChunks.Count > 0 && spawnedChunks[0].End.position.z < PoliceCar.position.z - 30)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0,ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);


    }

    // private Chunk GetRandomChunk()
    // {
    //     List<float> chances = new List<float>();
    //     for (int i = 0; i < ChunkPrefabs.Length; i++)
    //     {                                                          /*Player*/ 
    //         chances.Add(ChunkPrefabs[i].ChanceFromDistance.Evaluate(PoliceCar.transform.position.z));
    //     }

    //     float value = Random.Range(0, chances.Sum());
    //     float sum = 0;

    //     for (int i = 0; i < chances.Count; i++)
    //     {
    //         sum += chances[i];
    //         if (value < sum)
    //         {
    //             return ChunkPrefabs[i];
    //         }
    //     }

    //     return ChunkPrefabs[ChunkPrefabs.Length-1];
    // }
}