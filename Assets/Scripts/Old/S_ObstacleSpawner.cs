using System.Collections;
using UnityEngine;

public class S_ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacle;
    private S_PlayerController2 playerController;

    [Header("Private Settings")]
    private Vector3 spawnPos;
    public float spawnRangeX;
    public float spawnRangeZ;

    [Header("Adjustables")]
    public float minRate;
    public float maxRate;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<S_PlayerController2>();
        spawnPos = transform.position;
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop ()
    {
        while (playerController.playerAlive == true)
        {
            float delay = Random.Range(minRate, maxRate);
            yield return new WaitForSeconds(delay);

            SpawnObstacle();
        }
    }

    void SpawnObstacle ()
    {
        int objectIndex = Random.Range(0, obstacle.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.5f, spawnRangeZ);

        Instantiate(obstacle[objectIndex], spawnPos, obstacle[objectIndex].transform.rotation);
    }
}
