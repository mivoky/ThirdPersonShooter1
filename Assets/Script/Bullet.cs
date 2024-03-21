using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 5f;
    public float damage = 10f;
    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }
    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        var EnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (EnemyHealth != null)
        {
            EnemyHealth.dealDamage(damage);
        }

        DestroyBullet();

    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}


