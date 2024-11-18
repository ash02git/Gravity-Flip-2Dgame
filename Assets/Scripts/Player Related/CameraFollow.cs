using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    private void Update()
    {
        transform.position = new Vector3(Player.position.x,transform.position.y,transform.position.z);
    }
}
