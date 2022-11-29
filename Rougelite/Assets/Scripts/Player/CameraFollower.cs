using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothness = 0.2f;

    public void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, player.position, smoothness*Time.deltaTime);
    }
}
