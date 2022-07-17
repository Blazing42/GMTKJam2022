using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float bulletLifespan;

    private void Start()
    {
        Invoke(nameof(BulletTime), bulletLifespan);
    }
    void Update()
    {
        transform.position += Time.deltaTime * Speed * Vector3.forward;
    }

    void BulletTime()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObj = other.gameObject;
        if (collidedObj.tag == "Enemy")
        {
            Debug.Log("hit");
            collidedObj.GetComponent<EnemyMovement>().GetHit();
            BulletTime();
        }
    }

}
