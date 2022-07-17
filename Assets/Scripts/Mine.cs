using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] GameObject ExplosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            other.gameObject.GetComponent<EnemyMovement>().GetHit();
        }
        //Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Invoke(nameof(Destroy), 0.1f);
    }
    private void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}
