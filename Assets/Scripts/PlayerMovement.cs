using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.6f;
    [SerializeField] float RayDist = 0f;
    [SerializeField] LayerMask layerMask;

    [SerializeField] AudioClip rollSFX;
    [SerializeField] float volume = 0.5f;

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
            move(Vector3.forward, Vector3.left, input);
            AudioSystem.AudioSystemInstance.PlayAudioCLip(rollSFX, 0.5f);
            return;
        }

        input = Input.GetAxisRaw("Horizontal");
        if (input != 0)
        {
            move(Vector3.right, Vector3.forward, input);
            AudioSystem.AudioSystemInstance.PlayAudioCLip(rollSFX, 0.5f);
            return;

        }
    }
    void snap()
    {
        transform.position = targetPosition;
        transform.rotation = targetRotation;
        moving = false;
    }
    void move(Vector3 MoveDirection, Vector3 TurnAxis, float input)
    {
        if (!Physics.Raycast(transform.position, MoveDirection * input, RayDist, layerMask, QueryTriggerInteraction.Ignore))
        {
            targetPosition = transform.position + MoveDirection * input;
            startPosition = transform.position;
            startRotation = transform.rotation;
            transform.Rotate(TurnAxis, -input * 90, Space.World);
            targetRotation = transform.rotation;
            moving = true;
        }
     }
}
