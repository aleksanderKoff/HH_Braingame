using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3((float)0.2, (float)0.2, (float)0.2);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3((float)-0.2, (float)0.2, (float)0.2);

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, 5);
    }
}
