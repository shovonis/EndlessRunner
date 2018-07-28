using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour
{
    public GameObject[] grassRoadPrefabs;

    private Transform playerTransform;
    private float spwanZ = -7.6f;
    private float grassLength = 7.6f;
    private int numberOfGrassOnScreen = 8;
    private float safeZone = 12.0f;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeGrass;

    void Start()
    {
        activeGrass = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < numberOfGrassOnScreen; i++)
        {
            if (i < 5)
            {
                SpwanGrass(0);
            }
            else
            {
                SpwanGrass();
            }
        }
    }

    void Update()
    {
        if (playerTransform.position.z - safeZone > spwanZ - numberOfGrassOnScreen * grassLength)
        {
            SpwanGrass();
            DeleteGrass();
        }
    }

    private void SpwanGrass(int prefabIndex = -1)
    {
        GameObject grassRoad;
        if (prefabIndex == -1)
        {
            grassRoad = Instantiate(grassRoadPrefabs[GetRandomPrefabIndex()]);
        }
        else
        {
            grassRoad = Instantiate(grassRoadPrefabs[0]);
        }

        grassRoad.transform.SetParent(transform);
        grassRoad.transform.position = Vector3.forward * spwanZ;
        spwanZ += grassLength;
        activeGrass.Add(grassRoad);
    }

    private void DeleteGrass()
    {
        Destroy(activeGrass[0]);
        activeGrass.RemoveAt(0);
    }

    private int GetRandomPrefabIndex()
    {
        if (grassRoadPrefabs.Length == 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, grassRoadPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return lastPrefabIndex;
    }
}