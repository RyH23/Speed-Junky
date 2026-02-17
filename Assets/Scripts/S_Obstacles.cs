using UnityEngine;

public class S_Obstacles : MonoBehaviour
{
    // Component References
    private S_GameManager gameManager;

    // Variables
    private float _speed;
    private AudioSource _crashClips;
    public AudioClip crash1;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<S_GameManager>();
        _crashClips = GetComponent<AudioSource>();

        _speed = gameManager.gameSpeed;
    }

    ///////////////////////// OBSTACLES /////////////////////////
    private void Update()
    {
        if (gameManager.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("TEST");
            _crashClips.PlayOneShot(crash1, 1);
            gameManager.gameOver = true;
        }
    }
    ////////////////////////////////////////////////////////////
}
