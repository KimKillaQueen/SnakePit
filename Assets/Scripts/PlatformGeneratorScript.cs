using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject platformPrefab;
    [SerializeField] public List<Transform> spawnPoints;
    [SerializeField] public float platformSpawnRate = 0.01f;

    public float diff = 0.3f;
    private GameObject prevPlatform;

    void Start()
    {
        spawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnPlatform() {
        if(spawnPoints.Count > 0) {
            Vector3 offset = Vector3.zero;
            if(prevPlatform) {
                offset = (prevPlatform.transform.position.y + diff) * Vector3.up;
            }
            int spawnPointIndex = Random.Range(0, spawnPoints.Count);
            prevPlatform = GameObject.Instantiate(platformPrefab, spawnPoints[spawnPointIndex].position + offset, Quaternion.identity);
            StartCoroutine("platformTimer");
        }
    }

    IEnumerator platformTimer() {
        yield return new WaitForSeconds(platformSpawnRate);
        Debug.Log("spawning next platform");
        spawnPlatform();
    }
}
