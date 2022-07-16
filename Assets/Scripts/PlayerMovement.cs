using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.6f;

    private Vector3 targetPosition;
    private Vector3 startPosition;

    private bool moving = false;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (moving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                moving = false;
                return;
            }

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            targetPosition = transform.position + Vector3.forward * Input.GetAxisRaw("Vertical");
            startPosition = transform.position;
            moving = true;
            return;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            targetPosition = transform.position + Vector3.right * Input.GetAxisRaw("Horizontal");
            startPosition = transform.position;
            moving = true;
            return;
        }
    }
}
