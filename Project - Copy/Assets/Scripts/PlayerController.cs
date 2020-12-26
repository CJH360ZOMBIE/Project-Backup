using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed; 
    public float Jumpforce; 
    public Rigidbody2D rb; 
    private float MoveInput;
    public bool IsGrounded; 
    public Transform GroundCheck; 
    public float CheckRadius; 
    public LayerMask GroundLayer; 
    private int ExtraJumps; 
    public int ExtraJumpValue; 
    bool IstouchingFront; 
    public Transform FrontCheck; 
    bool WallSliding; 
    public float WallSlidingSpeed; 
    bool FacingRight =  true; 
    bool WallJumping;
    public float XwallForce; 
    public float YwallForce;  
    public float WallJumpTime; 
    

    // Start is called before the first frame update
    void Start()
    {
        ExtraJumps = ExtraJumpValue; 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, GroundLayer);

        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (MoveInput * Speed, rb.velocity.y);  
    }

    void Update()
    {
        if (IsGrounded == true)
        {
            ExtraJumps = ExtraJumpValue; 
        }
        if (Input.GetButtonDown("Jump") && ExtraJumps > 0)
        {
            rb.velocity = Vector2.up * Jumpforce;
            ExtraJumps--;
        } else if (Input.GetButtonDown("Jump") && ExtraJumps == 0 && IsGrounded == true)
        {
            rb.velocity = Vector2.up * Jumpforce; 
        }

        IstouchingFront = Physics2D.OverlapCircle(FrontCheck.position, CheckRadius, GroundLayer);

        if (IstouchingFront == true && IsGrounded == false && MoveInput != 0)
        {
            WallSliding = true; 
        } else
        {
            WallSliding = false; 
        }

        if (WallSliding)
        {
            rb.velocity = new Vector2 (rb.velocity.x, Mathf.Clamp(rb.velocity.y, -WallSlidingSpeed, float.MaxValue));
        }

        if (Input.GetButtonDown("Jump") && WallSliding == true)
        {
            WallJumping = true; 
            Invoke ("SetWallJumpingToFalse", WallJumpTime);
        }

        if (WallJumping == true)
        {
            rb.velocity = new Vector2(XwallForce * -MoveInput, YwallForce);
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis (rotZ, Vector3.forward);

        transform.rotation = Quaternion.Euler(0f, 180f, 0); 


        if(rotZ < 89 && rotZ > -89)
        {
            return;
        } 
        else
        {
            Flip();
        }

    }

    void Flip()
    {
        FacingRight = !FacingRight; //if true, will be false, if false, will be true. 
        transform.Rotate (0f, 180f, 0f); 
    }

    void SetWallJumpingToFalse()
    {
        WallJumping = false;
    }
}
