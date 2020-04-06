using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D playerRB;
    public Sprite idleSprite;
    public Sprite hoppingSprite;
    [SerializeField] public LayerMask platformLayer;
    void Start()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(playerRB.position, Vector3.down, 1.0f, platformLayer);
        if(playerRB.velocity.y > 0) {
            GetComponent<SpriteRenderer>().sprite = hoppingSprite;
        } else if(hit.collider) {
            GetComponent<SpriteRenderer>().sprite = idleSprite;
        }

        if(playerRB.velocity.x > 0) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if(playerRB.velocity.x < 0) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
