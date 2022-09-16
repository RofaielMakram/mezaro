using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Move
    public float Horizontal;
    public float Vertical;
    //public float maxRunSpeed;
    public float runSpeed;

    // Rotate
   // public float maxSpeedRotate;
    public float SpeedRotate;
    private float RotateX;

    //Animation
    [SerializeField]Animator animator;



    void Start() 
    {
        //runSpeed = maxRunSpeed;
       // SpeedRotate = maxSpeedRotate;
    }
    void Move(Vector2 direction)
    {
        transform.position += transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime;
    }

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        Move();
        Rotate();
        motion();
    }
    
    void Move()
    {
        Vector2 direction = new Vector2(Vertical * runSpeed, Horizontal * runSpeed); 
        Move(direction);
    }

    void motion() 
    {
        animator.SetFloat("Vertical", Vertical);
        animator.SetFloat("Horizontal", Horizontal);
    }

    void Rotate()
    {
        RotateX += SpeedRotate*Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, RotateX,0.0f);
    }
}
