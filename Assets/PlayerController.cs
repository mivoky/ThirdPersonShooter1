using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float gravity = 9.6f;
    public float jumpForce;
    public float RunConf = 2;
    public float speed = 2;

    private Vector3 _moveVector;
    private CharacterController _characterControler;

    private float _runConf;
    private float _fallVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        _characterControler = GetComponent<CharacterController>();
        _runConf = RunConf;
        RunConf = 1;
    }
    private void Update()
    {
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) 
            {
                _moveVector += transform.forward;
            }
        if (Input.GetKey(KeyCode.S))
            {
                _moveVector -= transform.forward;
            }
        if (Input.GetKey(KeyCode.D))
            {
                _moveVector += transform.right;
            }
        if (Input.GetKey(KeyCode.A))
            {
                _moveVector -= transform.right;
            }
        if (Input.GetKeyDown(KeyCode.Space) && _characterControler.isGrounded)
            {
                _fallVelocity = -jumpForce;
            }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            RunConf = _runConf;
        }
        else
        {
            RunConf = 1;
        }

        AnimatorController();

    }
    // Update is physic
    void FixedUpdate()
    {
        _characterControler.Move(_moveVector * speed * RunConf * Time.fixedDeltaTime);

        _fallVelocity += gravity + Time.fixedDeltaTime;
        _characterControler.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if(_characterControler.isGrounded) 
        {
            _fallVelocity = 0;
        }
    }
    void AnimatorController()
    {
        if (_moveVector != Vector3.zero)
        {
            animator.SetBool("isRun", true);
        }
        if (_moveVector == Vector3.zero)
        {
            animator.SetBool("isRun", false);
        }
        if (_characterControler.isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
    }
}
