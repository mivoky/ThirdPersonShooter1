using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody GrenadePrefab;
    public Transform GrenadeSourceTransform;

    public float Force = 10f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {        
            var Grenade = Instantiate(GrenadePrefab);
            Grenade.transform.position = GrenadeSourceTransform.position;
            Grenade.GetComponent<Rigidbody>().AddForce(GrenadeSourceTransform.forward * Force);
        }
    }
}
