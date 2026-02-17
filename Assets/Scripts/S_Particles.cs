using UnityEngine;

public class S_Particles : MonoBehaviour
{
    private S_GameManager gameManager;
    private ParticleSystem dustTrail;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<S_GameManager>();

        dustTrail = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (gameManager.gameOver == true)
        {
            dustTrail.Stop();
        }
    }
}
