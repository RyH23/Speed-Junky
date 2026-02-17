using UnityEngine;

public class S_FollowPlayer : MonoBehaviour
{
    ///////////////////////////Variables///////////////////////////////////
    public GameObject player;
    public float cameraHeight = 3;
    public float cameraXLength = 0.0f;
    public float cameraZLength = -8;
 
    ///////////////////////////Update///////////////////////////////////
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(cameraXLength, cameraHeight, cameraZLength);
    }
    //////////////////////////////////////////////////////////////
}
