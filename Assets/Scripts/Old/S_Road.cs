using UnityEngine;

public class S_Road : MonoBehaviour
{
    public float speed;
    private S_PlayerController2 playerController; 

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<S_PlayerController2>();
    }

    private void Update()
    {
        if (playerController.playerAlive == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

    }

}
