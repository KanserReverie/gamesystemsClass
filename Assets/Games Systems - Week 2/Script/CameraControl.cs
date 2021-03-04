using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // Camera following player at the end of each frame
    public Transform player;
    private void LateUpdate()
    {
        transform.position = new Vector3(
            player.position.x,
            player.position.y,
            -10);
    }
}
