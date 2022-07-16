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
            }

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }

        float input = Input.GetAxisRaw("Vertical");
        if (input != 0)
        {
            targetPosition = transform.position + Vector3.forward * input;
            startPosition = transform.position;
            //transform.eulerAngles = transform.eulerAngles + new Vector3(90 * input, 0, 0);
            transform.Rotate(Vector3.right, input * 90, Space.World);
            moving = true;
            return;
        }

        input = Input.GetAxisRaw("Horizontal");
        if (input != 0)
        {
            targetPosition = transform.position + Vector3.right * input;
            startPosition = transform.position;
            //transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 90 * input);
            {
                transform.Rotate(Vector3.forward, -input * 90, Space.World);
            }
            
            moving = true;
            return;
        }
    }
    void snap()
    {
        transform.position = targetPosition;
        moving = false;
        return;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);
        Debug.DrawLine(transform.position, transform.position + transform.right, Color.green);
    }
   
}
