using UnityEngine;

public class S_RoadSpawner : MonoBehaviour
{
    // Component References
    private S_GameManager gameManager;

    // Variables
    private float _speed;
    [SerializeField] float _maxRangeX = 140;
    private Vector3 _startPos;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<S_GameManager>();

        _startPos = transform.position;
        _speed = gameManager.gameSpeed;
    }
    private void Update()
    {
        _speed = gameManager.gameSpeed;

        if (gameManager.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }

        if (transform.position.z < _maxRangeX)
        {
            transform.position = _startPos;
        }
    }
}
