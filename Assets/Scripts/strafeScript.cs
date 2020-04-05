using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strafeScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D playerRB;
    [SerializeField] public float strafeSpeed = 3.0f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = playerRB.velocity.y * Vector2.up + (Input.GetAxisRaw("Horizontal") * strafeSpeed * Vector2.right * Time.deltaTime);
    }
}
