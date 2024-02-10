using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.6f;
    public float jumpForce;

    public float speed = 2;
    private Vector3 _moveVector;
    private CharacterController _characterControler;
    private float _fallVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        _characterControler = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) 
            {
                _moveVector += transform.forward;
            }
        if (Input.GetKeyDown(KeyCode.Space) && _characterControler.isGrounded)
            {
                _fallVelocity = -jumpForce;
            }
        
    }
    // Update is physic
    void FixedUpdate()
    {
        _characterControler.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity + Time.fixedDeltaTime;
        _characterControler.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }
}
