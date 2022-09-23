using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ArcherController : MonoBehaviour
{


    //Move
    public float Horizontal;
    public float Vertical;
    public float maxRunSpeed;
    [SerializeField] float runSpeed;

    // Rotate
    public float maxSpeedRotate;
    [SerializeField] float SpeedRotate;
    private float RotateX;

    //Animation
    [SerializeField]Animator animator;



    private void Start() 
    {
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
        Sprint();
        Dive();
        Punch();
        Kick();
    }
    
    void Move()
    {
        runSpeed = maxRunSpeed;

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
        SpeedRotate = maxSpeedRotate;
        RotateX += SpeedRotate*Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, RotateX,0.0f);
    }

    void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            maxRunSpeed = 6;
            animator.SetBool("sprint", true);
        }else
        {
            maxRunSpeed = 3;
            animator.SetBool("sprint", false);
        }

        if(Input.GetButton("Fire1"))
        {
             maxRunSpeed = 3;
            animator.SetBool("sprint", false);
        }
    }


    void Dive()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            animator.SetBool("dive", true);
        
        }else
        {
            animator.SetBool("dive", false);
        }
    }

    void Punch()
    {
        if(Input.GetKey(KeyCode.G)){
            animator.SetBool("melee punch", true);
        
        }else
        {
            animator.SetBool("melee punch", false);
        }
    }


    void Kick()
    {
        if(Input.GetKey(KeyCode.H)){
            animator.SetBool("melee kick", true);
        
        }else
        {
            animator.SetBool("melee kick", false);
        }
    }
    
    
}
