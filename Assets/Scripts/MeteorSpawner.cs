using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
    public float spawnRatePerMinute = 30;
    public float spawnRateIncrement = 1;
    private float spawnNext = 0;
    private List<GameObject> meteors = new List<GameObject>();


    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            meteors.Add(Instantiate(meteor, Vector3.zero, Quaternion.identity));
            meteor.SetActive(false);
            meteors.Add(meteor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + (60 / spawnRatePerMinute);
            spawnRatePerMinute += spawnRateIncrement;

            SpawnMeteor();
        }
    }

    private void SpawnMeteor()
    {
        // Spawn meteor
        GameObject meteor = GetInactiveMeteor();
        if (meteor != null)
        {
            float randomX = Random.Range(-8, 8);
            meteor.transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
            meteor.SetActive(true);
        }

    }

    private GameObject GetInactiveMeteor()
    {
        foreach (var meteor in meteors)
        {
            if (!meteor.activeSelf)
            {
                return meteor;
            }
        }
        return null;
    }
}
