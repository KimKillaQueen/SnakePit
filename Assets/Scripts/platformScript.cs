using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D platformRB;
    void Start()
    {
        platformRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void fall() {
        platformRB.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine("despawn");
    }

    IEnumerator despawn() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
