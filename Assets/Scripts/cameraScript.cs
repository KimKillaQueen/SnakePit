using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float xPos;
    private float yPos;
    public float paddingBottom = 0.05f;
    void Start()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yPos - paddingBottom) {
            transform.position = xPos * Vector3.right + Vector3.up * yPos + Vector3.forward * transform.position.z;
        } else {
            transform.position = xPos * Vector3.right + Vector3.up * transform.position.y + Vector3.forward * transform.position.z;
            yPos = transform.position.y;
        }
    }
}
