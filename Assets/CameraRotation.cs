using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Берем Transform из объекта
    public Transform CameraAxisTransform;
    // Угол камеры
    public float minAngle;
    public float maxAngle;
    // Скорость камеры
    public float RotateSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotateSpeed * Input.GetAxis("Mouse X"), 0);

        var newAngleX = CameraAxisTransform.localEulerAngles.x + Time.deltaTime * RotateSpeed * Input.GetAxis("Mouse Y") * -1;
        if (newAngleX >= 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        Debug.Log(newAngleX);

        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
