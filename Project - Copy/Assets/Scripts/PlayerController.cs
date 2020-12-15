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
    }
}
