using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    
    [SerializeField] public LayerMask jumpableGround;


    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] public float jumpForce = 14f;
    float angle;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        TurnCharacter();
       
    }
    public void Jump()
    {
        rb.velocity = new Vector2(0, jumpForce);
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void TurnCharacter()
    {
        int layerMask = 1 << 8; //määrittää mikä layer otetaan mukaan layermaskiin joka annetaan Raycastille, tässä tapauksessa 'Platform' rayvast katsoo ainoastaan tätä layeria sitten
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.2f, 0, 0), -transform.up, Mathf.Infinity, layerMask);

        angle = Vector3.Angle(hit.normal, new Vector3(0, 1, 0));

        if (hit.normal.x > 0)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle); 

        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 20;
        //Debug.DrawRay(transform.position + new Vector3(0.7f, 0, 0), -transform.up, Color.red); 

        //Näillä saa näkyvän DrawRay:n jos haluaa alkaa vielä jotain debuggailemaan


    }

}
