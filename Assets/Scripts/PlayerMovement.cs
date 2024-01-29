using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool ReadytoJump;
    [Header("Keybinds")]
    public KeyCode jumpkey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform Follow;
    public HealthSystem playerHealth;

    float horizontal;
    float vertical;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        playerHealth = GetComponent<HealthSystem>();
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        input();
        Speedcontrol();
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    
        
    }

    private void FixedUpdate()
    {
        Movement();
    }
    private void input()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Walking", Mathf.Abs(horizontal));
        animator.SetFloat("Walking", Mathf.Abs(vertical));



        if (Input.GetKey(jumpkey))
        {
            animator.SetTrigger("Jump");

            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetKey(KeyCode.None))
        {
            animator.SetFloat("Walking", 0);
        }

    }

    private void Movement()
    {
        moveDirection = Follow.forward * vertical + Follow.right * horizontal;
        if (grounded) 
            rb.AddForce(moveDirection * moveSpeed * 50f, ForceMode.Force);
           

        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(moveDirection * moveSpeed * 125f, ForceMode.Force);

            StartRunning();


        }


        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 15f * airMultiplier, ForceMode.Force);
        StopRunning();
    }

    private void Speedcontrol()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

        }
    }


    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 00f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        
    }
    private void ResetJump()
    {
        ReadytoJump = true;
    }

    void StartRunning()
    {
        animator.SetBool("Running", true);
        // Koþma animasyonu veya baþka bir koþma iþlemi burada baþlatýlabilir
    }

    void StopRunning()
    {
        animator.SetBool("Running", false);
        // Koþma animasyonu veya baþka bir koþma iþlemi burada durdurulabilir
    }

}
