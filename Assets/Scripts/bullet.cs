using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float Speed;
 
    void Update()
    {
        transform.position += Time.deltaTime * Speed * Vector3.back;
    }
}
