using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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
    public int livesRemaining = 4;
    public int maxHealth = 4;
    bool damaged;

    private void Awake()
    {
        targetPosition = transform.position;
        targetRotation = transform.rotation;
        livesRemaining = maxHealth;
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
            return;
        }

        input = Input.GetAxisRaw("Horizontal");
        if (input != 0)
        {
            move(Vector3.right, Vector3.forward, input);
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
            AudioSystem.AudioSystemInstance.PlayAudioCLip(rollSFX, volume);

            targetPosition = transform.position + MoveDirection * input;
            startPosition = transform.position;
            startRotation = transform.rotation;
            transform.Rotate(TurnAxis, -input * 90, Space.World);
            targetRotation = transform.rotation;
            moving = true;
        }
     }

    public void loseLife()
    {
        if(damaged == false)
        {
            livesRemaining -= 1;
            UIController.UIControllerInstance.LoseLife();
            damaged = true;
            Invoke(nameof(InvincibleForABitAfterTakingLife), 2f);
            if(livesRemaining <= 0)
            {
                Invoke(nameof(LoseGame),1f/* time for game over sounds and effects etc*/);
            }
        }  
    }

    void InvincibleForABitAfterTakingLife()
    {
        damaged = false;
    }

    void LoseGame()
    {
            SceneManager.LoadScene("GameOver");
    }
}
