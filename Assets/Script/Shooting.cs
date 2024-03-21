using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float Damage = 10;
    public Bullet bulletPrefab;
    public Transform bulletSourceTransform;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var Bullet = Instantiate(bulletPrefab, bulletSourceTransform.transform.position, bulletSourceTransform.transform.rotation);
            Bullet.damage = Damage;
        }
    }
}
