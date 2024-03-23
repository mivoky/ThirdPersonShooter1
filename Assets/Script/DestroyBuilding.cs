using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    public PlayerProgress PlayerProgress;
    public List<GameObject> Fragments;
    public float Health = 70;
    void Start()
    {

    }
    public void dealDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            for (int i = 0; i < Fragments.Count; i++)
            {
                Instantiate(Fragments[i], transform.position, transform.rotation);
            }
            Destroy(gameObject);

        }
    }
}
