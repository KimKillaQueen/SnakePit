using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class deathscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
            FindObjectOfType<Text>().text = "GAME OVER";
            StartCoroutine("killPlayer");
        }
    }

    IEnumerator killPlayer() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("SampleScene");
//        FindObjectOfType<Camera>().transform.parent = this.transform;
    }
}
