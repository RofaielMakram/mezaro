using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensitivity = 3f;


    [SerializeField]
    GameObject fbsCamera;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float CameraUpAndDownRotation = 0f;
    private float CurrentCameraUpAndDownRotation = 0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate movement velo,city as a 3d vector
        float _xMovement = Input.GetAxis("Horizontal");
        float _zMovement = Input.GetAxis("Vertical");

        Vector3 _movementHorizontal = transform.right * _xMovement;
        Vector3 _movementVertical = transform.forward * _zMovement;

        //Final movement velocity vector
        Vector3 _movementVelocity = (_movementHorizontal + _movementVertical).normalized * speed;

        //Apply movement
        Move(_movementVelocity);



        //calculate rotation as a 3D vector for turning around.
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _rotationVector = new Vector3(0,_yRotation,0)*lookSensitivity;

        
        //Apply rotation
        Rotate(_rotationVector);
       
               


    //Calculate look up and down camera rotation
    float _cameraUpDownRotation = Input.GetAxis("Mouse Y")*lookSensitivity;

    //Apply rotation 
    RotateCamera(_cameraUpDownRotation);    



    } 

    //runs per physcis iteretaion
    private void  FixedUpdate()
    {
        if (velocity!=Vector3.zero)
        {
            rb.MovePosition(rb.position+velocity*Time.fixedDeltaTime);


        }

        rb.MoveRotation(rb.rotation*Quaternion.Euler(rotation));



        if (fbsCamera!=null)
        {

        CurrentCameraUpAndDownRotation -= CameraUpAndDownRotation;
        CurrentCameraUpAndDownRotation = Mathf.Clamp(CurrentCameraUpAndDownRotation,-85,58);


        fbsCamera.transform.localEulerAngles = new Vector3(CurrentCameraUpAndDownRotation,0,0);



        }


    }
    


    void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }

    void Rotate(Vector3 rotationVector)
    {
        rotation = rotationVector;

    }

    void RotateCamera(float cameraUpAndDownRotation)
    {
        CameraUpAndDownRotation = cameraUpAndDownRotation;
    }
    


}
