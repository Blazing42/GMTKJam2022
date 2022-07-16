using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject FollowObject;
    public Vector3 Offset;
    public float Speed;

    private void Update()
    {
        Vector3 newpos = Vector3.Lerp(transform.position, FollowObject.transform.position + Offset, 1 - Mathf.Pow(1 - Speed, Time.deltaTime / 60));
        transform.position = newpos;
    }
}
