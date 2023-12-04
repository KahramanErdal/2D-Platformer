using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public float speed;
    public float jump;
    private float moveVelocity;
    public Rigidbody2D rb;
    private bool isGrounded;
    private bool canDoubleJump;

    void Update()
    {
        // Grounded?
        if (isGrounded)
        {
            canDoubleJump = true;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded || canDoubleJump)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);

                // If the double jump is used, set canDoubleJump to false
                if (!isGrounded)
                {
                    canDoubleJump = false;
                }
            }
        }

        moveVelocity = 0;

        // Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("OnCollisionExit2D");
        isGrounded = false;
    }
}
