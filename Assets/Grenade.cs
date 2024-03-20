using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float Damage = 30;

    public GameObject ExplosionPrefab;
    public float Delay = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", Delay);
    }
    private void Explosion()
    {
        Destroy(gameObject);
        var Explosion = Instantiate(ExplosionPrefab);
        Explosion.transform.position = transform.position;
        Explosion.GetComponent<Explosion>().Damage = Damage;
    }
}
