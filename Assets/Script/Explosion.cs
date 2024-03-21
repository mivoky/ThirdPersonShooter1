using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Damage = 50f;
    public float Speed = 1f;
    public float MaxSize = 2;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * Speed;
        if (transform.localScale.x > MaxSize)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var PlayerHeatlh = other.GetComponent<PlayerHealth>();
        if (PlayerHeatlh != null)
        {
            PlayerHeatlh.DealDamage(Damage);
        }
        var EnemyHeath = other.GetComponent<EnemyHealth>();
        if (EnemyHeath != null)
        {
            EnemyHeath.dealDamage(Damage);
        }
    }
}
