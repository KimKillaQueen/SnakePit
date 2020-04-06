using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D snakeRB;
    [SerializeField] public List<Transform> corners;
    [SerializeField] public float moveSpeed = 1.5f;
    public bool movingRight = true;
    private Sprite snakeSprite;
    public float offsetY;
    public Camera mainCam;
    void Start()
    {   
        snakeRB = GetComponent<Rigidbody2D>();
        if(movingRight) {
            snakeRB.velocity = Vector3.right * moveSpeed;
        } else {
            snakeRB.velocity = Vector3.left * moveSpeed;
        }

        offsetY = mainCam.transform.position.y + snakeRB.position.y;
        Debug.Log(mainCam.transform.position);
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight && transform.position.x > corners[1].position.x) {
            movingRight = false;
            snakeRB.velocity = Vector3.left * moveSpeed;
        } else if(!movingRight && transform.position.x < corners[0].position.x) {
            movingRight = true;
            snakeRB.velocity = Vector3.right * moveSpeed;
        }

        GetComponent<SpriteRenderer>().flipX = !movingRight;
        transform.position = Vector3.up * (mainCam.transform.position.y + offsetY) + Vector3.right * transform.position.x + Vector3.forward * transform.position.z;
    }
}
