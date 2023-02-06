using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    // defult clothes
    public SkinnedMeshRenderer pant,bra;

    //Move
    [SerializeField]
    cameraControl camera;
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

    public bool aim;



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
<<<<<<< HEAD
        AimMoveDefualt();
        AimMove();
=======
        
>>>>>>> 7b09098d90653d10260f5de580f31496573bd556
    }
    
    void Move()
    {
        runSpeed = maxRunSpeed;

        Vector2 direction = new Vector2(Vertical * runSpeed, Horizontal * runSpeed); 
        Move(direction);
        //test
        if (maxRunSpeed < 6 && camera.aiming == false)
        {
            animator.SetLayerWeight(3, 0.6f);
        }
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

    public void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
<<<<<<< HEAD
            // maxRunSpeed = 6;
=======
            maxRunSpeed = 6;
            animator.SetLayerWeight(3, 0);
>>>>>>> 7b09098d90653d10260f5de580f31496573bd556
            animator.SetBool("sprint", true);
        }else
        {
            maxRunSpeed = 3;
            animator.SetBool("sprint", false);
           
        }

        // if(Input.GetButton("Fire1"))
        // {
        //      maxRunSpeed = 3;
        //     animator.SetBool("sprint", false);
        // }
    }

    public void AimMoveDefualt()
    {
        if (aim == false) 
        {
            maxRunSpeed = 6;
        }
    }

    public void AimMove()
    {
        if (aim == true) 
        {
            maxRunSpeed = 3;
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
