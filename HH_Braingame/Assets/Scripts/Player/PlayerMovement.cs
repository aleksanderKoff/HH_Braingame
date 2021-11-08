using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    float angle = 0;

    [SerializeField] public LayerMask jumpableGround;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] public float jumpForce = 14f;

   
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        
        if (SceneManager.GetActiveScene().name == "StartMenu")
            moveSpeed = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.A) && SceneManager.GetActiveScene().name == "StartMenu")
        {
            Jump();
        }

        TurnCharacter();
    }
    public void Jump()
    {
        if (rb)
            rb.velocity = new Vector2(0, jumpForce);
        SfxManager.PlaySound("MenuMove");
    }

    public void DodgeLeft() //move player left
    {
        if(rb)
            rb.velocity = new Vector2(-8f, 0);
    }
    public void DodgeRight() //move player right
    {
        if (rb)
            rb.velocity = new Vector2(8f, 0);
    }

    public bool IsGrounded() //check if player is touching ground
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void TurnCharacter()
    {

        int layerMask = 1 << 8; //määrittää mikä layer otetaan mukaan layermaskiin joka annetaan Raycastille, tässä tapauksessa 'Platform'. raycast katsoo ainoastaan t�t� layeria sitten

        RaycastHit2D frontSensor = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0, 0), -transform.up, 2, layerMask);
        RaycastHit2D backSensor = Physics2D.Raycast(transform.position + new Vector3(0.1f, 0, 0), -transform.up, 2, layerMask);


        if (frontSensor.normal.x > 0 && backSensor.normal.x > 0 && Mathf.Abs(frontSensor.normal.x - backSensor.normal.x) < 0.05)
            angle = -Vector3.Angle(frontSensor.normal, new Vector3(0, 1, 0));
        else if (frontSensor.normal.x < 0 && backSensor.normal.x < 0 && Mathf.Abs(frontSensor.normal.x - backSensor.normal.x) < 0.05)
            angle = Vector3.Angle(frontSensor.normal, new Vector3(0, 1, 0));

        if (angle <= 45 && angle >= -45)
            transform.rotation = Quaternion.Euler(0, 0, angle);

        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 20;
        //Debug.DrawRay(transform.position + new Vector3(0.7f, 0, 0), -transform.up, Color.red);

        //Näillä saa näkyvän DrawRay:n jos haluaa alkaa vielä jotain debuggailemaan
    }

    public void StopCharacter()
    {
        moveSpeed = 0;
    }


}
