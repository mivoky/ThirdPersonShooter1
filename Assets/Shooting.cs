using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform bulletSourceTransform;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, bulletSourceTransform.transform.position, bulletSourceTransform.transform.rotation);
        }
    }
}
