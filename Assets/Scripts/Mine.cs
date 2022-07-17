using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mine : MonoBehaviour
{
    [SerializeField] GameObject ExplosionPrefab;
    public AudioClip pop;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            other.gameObject.GetComponent<EnemyMovement>().GetHit();
        }
        AudioSystem.AudioSystemInstance.PlayAudioCLip(pop, 0.7f);
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Invoke(nameof(Destroy), 0.3f);
    }
    private void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}
