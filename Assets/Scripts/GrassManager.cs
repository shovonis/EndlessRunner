using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrassManager : MonoBehaviour
{
    public GameObject[] grassRoadPrefabs;
    public GameObject Wave;

    private Transform playerTransform;

    private float spwanZ = -7.6f;
    private float grassLength = 7.5f;
    private int numberOfGrassOnScreen = 8;
    private int numberOfActiveWaveOnScreen = 2;
    private float safeZone = 12.0f;
    private int lastPrefabIndex;

    private float waveLegth = 374.0f;
    private float waveSpanZ = -5.0f;

    private List<GameObject> activeGrass;
    private List<GameObject> activeWave;

    void Start()
    {
        activeGrass = new List<GameObject>();
        activeWave = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < numberOfActiveWaveOnScreen; i++)
        {
            SpanWave();
        }

        for (int i = 0; i < numberOfGrassOnScreen; i++)
        {
            if (i < 6)
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

        if (playerTransform.position.z > waveSpanZ - waveLegth)
        {
            Debug.Log("New Wave Spanned");
            SpanWave();
            DeleteWave();
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

    private void SpanWave()
    {
        GameObject wave = Instantiate(Wave);
        wave.transform.SetParent(transform);
        wave.transform.position = new Vector3(0, -1.0f, waveSpanZ);
        waveSpanZ += waveLegth;
        activeWave.Add(wave);
    }

    private void DeleteGrass()
    {
        Destroy(activeGrass[0]);
        activeGrass.RemoveAt(0);
    }

    private void DeleteWave()
    {
        Destroy(activeWave[0]);
        activeWave.RemoveAt(0);
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