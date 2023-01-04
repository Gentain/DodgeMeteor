using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour
{
    public float generateLength = 5f; 
    public GameObject obj;
    public float interval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", 0.1f, interval);
    }

    // Update is called once per frame
    void SpawnObj()
    {
        Instantiate(obj, new Vector3(Random.Range(-generateLength, generateLength), transform.position.y, transform.position.z), transform.rotation);
    }
}
