using UnityEngine;

public class S_rotate : MonoBehaviour
{
    private S_GameManager gameManager;

    [SerializeField] float rotationSpeed = 30;
    [SerializeField] float maxAngle = 25;
    [SerializeField] float returnSpeed = 35;
    [SerializeField] float resetDistance = 5.5f;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<S_GameManager>();
    }
    void Update()
    {
        float playerZ = transform.localEulerAngles.z;

        if (playerZ > 180)
        {
            playerZ -= 360;

        }

        bool isTurning = false; 

        if (gameManager.gameOver == true)
        {

        } else
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerZ += rotationSpeed * Time.deltaTime;
                isTurning = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                playerZ -= rotationSpeed * Time.deltaTime;
                isTurning = true;
            }

            if (transform.position.x >= resetDistance || transform.position.x <= -resetDistance)
            {
                playerZ = Mathf.MoveTowards(playerZ, 0, (returnSpeed * 2) * Time.deltaTime);

            }
            else if (!isTurning)
            {
                playerZ = Mathf.MoveTowards(playerZ, 0, returnSpeed * Time.deltaTime);
            }

            playerZ = Mathf.Clamp(playerZ, -maxAngle, maxAngle);

            transform.localEulerAngles = new Vector3(0, 0, playerZ);
        }
    }
}
