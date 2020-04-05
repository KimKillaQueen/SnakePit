using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float xPos;
    void Start()
    {
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = xPos * Vector3.right + Vector3.up * transform.position.y + Vector3.forward * transform.position.z;
    }
}
