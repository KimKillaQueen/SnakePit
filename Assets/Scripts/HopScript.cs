using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D playerRB;
    private bool grounded = false;
    private bool falling = true;
    [SerializeField] public LayerMask platforms;
    [SerializeField] public float hopSpeed = 3.0f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            grounded = false;
            StopAllCoroutines();
            StartCoroutine("hop");
        } else if (falling) {
            // RaycastHit2D out = ;
            Debug.DrawRay(playerRB.position + Vector2.down * GetComponent<CircleCollider2D>().radius, Vector2.down, Color.red);
            Debug.DrawRay(playerRB.position + Vector2.right * GetComponent<CircleCollider2D>().radius + GetComponent<CircleCollider2D>().radius * Vector2.down, Vector2.down, Color.red);
            Debug.DrawRay(playerRB.position + Vector2.left * GetComponent<CircleCollider2D>().radius + GetComponent<CircleCollider2D>().radius * Vector2.down, Vector2.down, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(playerRB.position + GetComponent<CircleCollider2D>().radius * Vector2.down, -Vector2.up, 0.1f, platforms);
            RaycastHit2D rightCheck = Physics2D.Raycast(playerRB.position + GetComponent<CircleCollider2D>().radius * Vector2.right + GetComponent<CircleCollider2D>().radius * Vector2.down, -Vector2.up, 0.1f, platforms);
            RaycastHit2D leftCheck = Physics2D.Raycast(playerRB.position + GetComponent<CircleCollider2D>().radius * Vector2.left + GetComponent<CircleCollider2D>().radius * Vector2.down, -Vector2.up, 0.1f, platforms);
            if(hit.collider != null || rightCheck.collider != null || leftCheck.collider != null) {
                grounded = true;
                Debug.Log("grounded");
                if(hit.collider) {
                    hit.collider.gameObject.GetComponent<platformScript>().fall();
                } else if (rightCheck.collider) {
                    rightCheck.collider.gameObject.GetComponent<platformScript>().fall();
                } else {
                    leftCheck.collider.gameObject.GetComponent<platformScript>().fall();
                }
                //Debug.Log(hit.collider.gameObject.name);
                
            }
        }
    }

    private IEnumerator hop()
    {
        // while()
        float jumpTimer = 0.00f;
        float maxJumpTime = 0.5f;
        falling = false;
        Debug.Log("Hopping");

        // playerRB.velocity = Vector2.right * playerRB.velocity.x + Vector2.up * 0.1f;
        while (!falling && !grounded)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer < maxJumpTime)
            {
                
                //  playerRB.AddForce(Vector2.up / jumpTimer);
                playerRB.velocity = playerRB.velocity.x * Vector2.right + (Vector2.up * hopSpeed) / jumpTimer;
                
            } else {
                falling = true;
                playerRB.velocity = Vector2.down * playerRB.gravityScale + playerRB.velocity.x * Vector2.right;
                Debug.Log("Falling");
            }
            yield return null;
        }

    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {

    //     if ((playerRB.position.y) > other.gameObject.GetComponent<Rigidbody2D>().position.y)
    //     {
    //         Debug.Log("Grounded");
    //         grounded = true;
    //     }
    // }
}
