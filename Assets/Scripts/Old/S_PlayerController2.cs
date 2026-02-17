using UnityEngine;

public class S_PlayerController2 : MonoBehaviour
{
    // References
    private CharacterController controller;
    public GameObject road;


    // Variables
    private float xRange = 10f;
    private float turnInput;

    public bool playerAlive = true;

    [Header("Movement Settings")]
    public float driveSpeed = 5f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        road = GameObject.Find("Road"); 
    }

    private void Update()
    {
        InputManagement();
        GroundMovement();
    }

    // Player Controller
    private void GroundMovement() // Movement Rules
    {
        Vector3 move = new Vector3(turnInput, 0 , 0);
        move *= driveSpeed;

        controller.Move(move * Time.deltaTime);

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, 1.1f, 0);
        } else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, 1.1f, 0);
        }
    }

    // Player Input
    private void InputManagement() 
    {
        turnInput = Input.GetAxis("Horizontal");
    }


    // If Player Collides With Objects
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Road"))
        {
            Debug.Log("New Road");
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            playerAlive = false;
        }
    }
}
