using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;
    public float initialSpeed = 6f;

    [SerializeField] Camera camera;
    [SerializeField] FixedJoystick joystick_move;
    [SerializeField] FixedJoystick joystick_turn;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidBody;
    int floorMask;
    float camRayLength = 100f;


    // Start is called before the first frame update
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

#if !MOBILE_INPUT
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
#else
        float h = joystick_move.Horizontal;
        float v = joystick_move.Vertical;
#endif

        Move(h, v);
        Turning();
        Animating(h, v);

    }

	void Move(float h, float v)
    {
        //movement.Set(h, 0, v);
#if !MOBILE_INPUT
        movement = movement.normalized;
#endif

        Vector3 cameraForward = camera.transform.forward;
        cameraForward.y = 0;

        Vector3 forward = cameraForward * v;
        Vector3 right = camera.transform.right * h;
        movement = forward + right;

        float speedScaled = speed * transform.lossyScale.x;
        movement *= speedScaled * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        if (joystick_turn.Horizontal == 0 && joystick_turn.Vertical == 0) { return; }

        print(camera.transform.forward);
        Vector3 cameraForward = camera.transform.forward;
        cameraForward.y = 0;

        Vector3 forward = cameraForward * joystick_turn.Vertical;
        Vector3 right = camera.transform.right * joystick_turn.Horizontal;

        Quaternion newRotation = Quaternion.LookRotation(forward + right);
        newRotation.x = 0;
        newRotation.z = 0;
        playerRigidBody.MoveRotation(newRotation);
    }

    /*
    void Turning()
    {
#if !MOBILE_INPUT
        Ray camRay = camera.ScreenPointToRay(playerRigidBody.position);//Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidBody.MoveRotation(newRotation);
        }
#else
        Vector3 playerToMouse = new Vector3(joystick_turn.Direction.x, 0.0f, joystick_turn.Direction.y);
        if(playerToMouse != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidBody.MoveRotation(newRotation);
        }       
#endif
    }*/

    void Animating(float h, float v)
    {
        bool walking = (h != 0f || v != 0f);
        anim.SetBool("IsWalking", walking);
    }
}
