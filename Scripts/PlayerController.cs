using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour
{
   

    Transform tr;
    Rigidbody rb;
   
 
    public float walkSpeed = 300;

   

    public bool OnGround;
   
    public bool Shooting;
    public bool Aiming;

    public Transform cameraShoulder;
    public Transform cameraHolder;
    public Transform aimingcamera;
    private Transform cam;

    private float rotY = 0f;

    public  float rotationSpeed = 200;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float cameraSpeed = 200;

    Animator anim;

    private Vector2 animSpeed;

    public PistolController pistol;

    void Start()
    {
        tr = this.transform;
        rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>();
        
        cam = Camera.main.transform;

      
    }

     void Update()
    {

       
        
       MoveControl();
       CameraControl();
     
       
        ActionsControl();
        ItemsControl();

        AnimControl();

    }

    public void MoveControl()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        float deltaT = Time.deltaTime;
        
        animSpeed = new Vector2 (deltaX, deltaZ);


        Vector3 side = walkSpeed * deltaX * deltaT * tr.right;
        Vector3 forward = walkSpeed * deltaZ * deltaT * tr.forward;

        Vector3 direction = side + forward;
       
        direction.y = rb.velocity.y;

        rb.velocity = direction;
    }

    public void ActionsControl()
    {
       

        Aiming = Input.GetKey(KeyCode.Mouse1);
        Shooting = Input.GetKeyDown(KeyCode.Mouse0);

    }

    public void ItemsControl()
    {
        if (pistol != null)
        {
            pistol.DrawSight(cam);
            if(Shooting)
            {
                pistol.Shoot();
            }
        }
        Cursor.lockState = (Input.GetKey(KeyCode.Escape) ? CursorLockMode.None : CursorLockMode.Locked);
      
    }

    
    public void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        rotY += mouseY * rotationSpeed * deltaT;
        
        float rotx = mouseX * rotationSpeed *deltaT;

        tr.Rotate(0,rotx,0);

        rotY =  Mathf.Clamp(rotY, minAngle, maxAngle);

        Quaternion localRotation = Quaternion.Euler(-rotY,0,0);
        cameraShoulder.localRotation = localRotation;
        if (Aiming)
        {
            cam.position = Vector3.Lerp(cam.position, aimingcamera.position, cameraSpeed * deltaT);
            cam.rotation = Quaternion.Lerp(cam.rotation, aimingcamera.rotation, cameraSpeed * deltaT);

        }
        else
        {
            cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT);
            cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);
        }

    }

    public void AnimControl()
    {
        anim.SetBool("ground", OnGround);
        anim.SetFloat("X", animSpeed.x);
        anim.SetFloat ("Y", animSpeed.y);
    }
}
