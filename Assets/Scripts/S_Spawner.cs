using System.Collections;
using UnityEngine;

public class S_Spawner : MonoBehaviour
{
    // Component References
    private S_GameManager gameManager;

    // Variables
    public GameObject[] obstacles;

    private float _minDelay = 0;
    public float _maxDelay = 2;

    [SerializeField] float _spawnRangeX = 7f;
    [SerializeField] float _spawnRangeZ = 430;
    [SerializeField] float _spawnRangeY = 1;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<S_GameManager>();

        StartCoroutine(GameStart());
    }

    private void Update()
    {
        SpawnRate(); 
    }
    ///////////////////////// SPAWNER /////////////////////////
    IEnumerator SpawnLoop()
    {
            while (gameManager.gameOver == false)
            {
                float _spawnDelay = Random.Range(_minDelay, _maxDelay);
                yield return new WaitForSeconds(_spawnDelay);

                SpawnObstacle();
            }
    }

    private void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstacles.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), _spawnRangeY, _spawnRangeZ);

        Instantiate(obstacles[obstacleIndex], spawnPos, obstacles[obstacleIndex].transform.rotation);
    }

    private void SpawnRate()
    {
            if (gameManager.gameSpeed >= 100)
            {
                _maxDelay = 1.5f;
            }

            if (gameManager.gameSpeed >= 150)
            {
                _maxDelay = 1;
            }

            if (gameManager.gameSpeed >= 200)
            {
                _maxDelay = 0.5f;
            }
    }
    ////////////////////////////////////////////////////////////

    /////////////////////// Start Game /////////////////////////
    private IEnumerator GameStart()
    {
        while (gameManager.gameStart == false)
        {
            yield return null;
        }

        StartCoroutine(SpawnLoop());
    }
    ////////////////////////////////////////////////////////////
}
