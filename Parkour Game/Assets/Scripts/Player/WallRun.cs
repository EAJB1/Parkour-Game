using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    public PlayerMovement PMscript;

    [Header("Movement")]
    [SerializeField] private Transform orientation;

    [Header("Detection")]
    [SerializeField] private float wallDistance = 0.5f;
    [SerializeField] private float minimumJumpHeight = 1.5f;

    [Header("Wall Running")]
    [SerializeField] private float wallRunGravity = 0.4f;
    [SerializeField] private float wallRunJumpForce = 3.25f;
    [SerializeField] public int wallCount = 0;

    //private float startTime = 0f;
    //private float timer = 0f;
    
    //[SerializeField] public float holdTime = 2.0f;
    //[SerializeField] private bool held = false;

    [Header("Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private float fov;
    [SerializeField] private float wallRunfov;
    [SerializeField] private float wallRunfovTime;
    [SerializeField] private float camTilt;
    [SerializeField] private float camTiltTime;

    public float tilt { get; private set; }
    
    public bool wallIsLeft = false;
    public bool wallIsRight = false;

    RaycastHit leftWallHit;
    RaycastHit rightWallHit;

    private Rigidbody rb;

    bool CanWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minimumJumpHeight);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void CheckWall()
    {
        wallIsLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallDistance);
        wallIsRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallDistance);
    }

    private void Update()
    {
        CheckWall();

        if (CanWallRun())
        {
            if (wallIsLeft)
            {
                StartWallRun();
            }
            else if (wallIsRight)
            {
                StartWallRun();
            }
            else
            {
                StopWallRun();
            }
        }
        else
        {
            StopWallRun();
        }

        // 'wallCount' and 'airMultiplier' resets to 0 when player lands on the ground.
        if (PMscript.isGrounded == true && wallCount != 0)
        {
            wallCount = 0;
            PMscript.airMultiplier = 0.4f;
        }
    }

    public void StartWallRun()
    {
        rb.useGravity = false;

        rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Force);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunfov, wallRunfovTime * Time.deltaTime);

        if (wallIsLeft)
            tilt = Mathf.Lerp(tilt, -camTilt, camTiltTime * Time.deltaTime);
        else if (wallIsRight)
            tilt = Mathf.Lerp(tilt, camTilt, camTiltTime * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            WallRuning();
        }

        
    }

    public void WallRuning()
    {
        if (wallIsLeft)
        {
            Vector3 wallRunJumpDirection = transform.up + leftWallHit.normal;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(wallRunJumpDirection * wallRunJumpForce * 100, ForceMode.Force);

            // While holding the left shift key, the 'wallCount' is incremented by 1 every time the player wall runs and increases the 'airMultiplier'.
            if (Input.GetKey(KeyCode.LeftShift))
            {
                wallCount++;

                if (wallCount > 1 && PMscript.airMultiplier < 1.0f)
                {
                    PMscript.airMultiplier += 0.05f;
                }
            }
        }
        else if (wallIsRight)
        {
            Vector3 wallRunJumpDirection = transform.up + rightWallHit.normal;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(wallRunJumpDirection * wallRunJumpForce * 100, ForceMode.Force);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                wallCount++;

                if (wallCount > 1 && PMscript.airMultiplier < 1.0f)
                {
                    PMscript.airMultiplier += 0.05f;
                }
            }
        }
    }

    public void StopWallRun()
    {
        rb.useGravity = true;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunfovTime * Time.deltaTime);
        tilt = Mathf.Lerp(tilt, 0, camTiltTime * Time.deltaTime);
    }
}
