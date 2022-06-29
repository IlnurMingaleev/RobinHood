using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private Joystick joystick;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveH = JoystickInput(joystick.Horizontal);
        moveV = JoystickInput(joystick.Vertical);
        rigidBody2D.velocity = new Vector2(moveH, moveV);//OPTIONAL rb.MovePosition();

        Vector2 direction = new Vector2(moveH, moveV);

        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }
    private float JoystickInput(float axis) 
    {
        if (axis >= .2f)
        {
           return moveSpeed;
        }
        else if (axis <= -.2f)
        {
           return -moveSpeed;
        }
        else
        {
            return  0;
        }

    }



}
