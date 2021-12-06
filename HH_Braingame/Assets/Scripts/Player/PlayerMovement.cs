using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    float playerAngleZ = 0;

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

    // Turns character according to the surrounding area
    public void TurnCharacter()
    {

        int raycastLayer = 8;
        int layerMask = 1 << raycastLayer;
        double acceptableAngleDifferenceLimit = 0.05;

        RaycastHit2D frontSensor = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0, 0), -transform.up, 2, layerMask);
        RaycastHit2D backSensor = Physics2D.Raycast(transform.position + new Vector3(0.1f, 0, 0), -transform.up, 2, layerMask);

        float angleFront = frontSensor.normal.x;
        float angleBack = backSensor.normal.x;

        if (angleFront > 0 && angleBack > 0 && CalculateAngleDifference(angleFront, angleBack) < acceptableAngleDifferenceLimit)
            playerAngleZ = -Vector3.Angle(frontSensor.normal, new Vector3(0, 1, 0));
        else if (angleFront < 0 && angleBack < 0 && CalculateAngleDifference(angleFront, angleBack) < acceptableAngleDifferenceLimit)
            playerAngleZ = Vector3.Angle(frontSensor.normal, new Vector3(0, 1, 0));

        if (playerAngleZ <= 45 && playerAngleZ >= -45)
            transform.rotation = Quaternion.Euler(0, 0, playerAngleZ);
    }

    private float CalculateAngleDifference(float angleFront, float angleBack)
    {

        float difference = Mathf.Abs(angleFront - angleBack);
        return difference;
    }

    public void StopCharacter()
    {
        moveSpeed = 0;
    }




}
