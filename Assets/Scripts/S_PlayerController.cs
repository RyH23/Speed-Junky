using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
    // Component References
    private CharacterController characterController;
    private S_GameManager gameManager;

    // Variables
    [SerializeField] float _turnSpeed = 5.0f;
    private float _xRange = 6.50f;
    private float _turnInput;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<S_GameManager>();

        ParticleSystem _dustTrail = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
 
            if (gameManager.gameOver == false)
            {
                InputManagement();
                PlayerMovement();
            }
    }


    //////////////////// PLAYER CONTROLLER ////////////////////
    private void PlayerMovement()
    {
        Vector3 movement = new Vector3(_turnInput, 0, 0);
        movement *= _turnSpeed;

        characterController.Move(movement * Time.deltaTime);

        if (transform.position.x > _xRange)
        {
            transform.position = new Vector3(_xRange, 1.3f, 0);
        } else if (transform.position.x < -_xRange)
        {
            transform.position = new Vector3(-_xRange, 1.3f, 0);
        }
    }

    private void InputManagement()
    {
        _turnInput = Input.GetAxis("Horizontal");
    }
    ////////////////////////////////////////////////////////////
}
