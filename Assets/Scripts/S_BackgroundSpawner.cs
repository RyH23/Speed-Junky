using System.Collections;
using UnityEngine;

public class S_BackgroundSpawner : MonoBehaviour
{
   private S_GameManager gameManager;
    public GameObject[] props;

    [SerializeField] float _minDelay;
    [SerializeField] float _maxDelay;

    [SerializeField] float _xRange1;
    [SerializeField] float _xRange2;
    [SerializeField] float _yRange;
    [SerializeField] float _zRange;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<S_GameManager>();

        StartCoroutine(GameStart());
    }

    private void Update()
    {
        SpawnRate();
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

    private IEnumerator GameStart()
    {
        while (gameManager.gameStart == false)
        {
            yield return null;
        }

        StartCoroutine(SpawnLoop());
    }

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
        int propsIndex = Random.Range(0, props.Length);
        Vector3 spawnPos = new Vector3(Random.Range(_xRange1, _xRange2), _yRange, _zRange);

        Instantiate(props[propsIndex], spawnPos, props[propsIndex].transform.rotation);
    }

}
