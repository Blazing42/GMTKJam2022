using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.6f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private bool moving = false;

    private void Awake()
    {
        targetPosition = transform.position;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (moving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                snap();
                return;
            }

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            float lerpAmount = Vector3.Distance(targetPosition, transform.position);
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, 1 - lerpAmount);
            return;
        }

        float input = Input.GetAxisRaw("Vertical");
        if (input != 0)
        {
            float inputSign = Mathf.Sign(input);
            targetPosition = transform.position + Vector3.forward * inputSign;
            startPosition = transform.position;
            startRotation = transform.rotation;
            transform.Rotate(Vector3.right, inputSign * 90, Space.World);
            targetRotation = transform.rotation;
            moving = true;
            return;
        }

        input = Input.GetAxisRaw("Horizontal");
        if (input != 0)
        {
            float inputSign = Mathf.Sign(input);
            targetPosition = transform.position + Vector3.right * inputSign;
            startPosition = transform.position;
            startRotation = transform.rotation;
            transform.Rotate(Vector3.forward, -inputSign * 90, Space.World);
            targetRotation = transform.rotation;
            moving = true;
            return;
        }
    }
    void snap()
    {
        transform.position = targetPosition;
        transform.rotation = targetRotation;
        moving = false;
    }
}
