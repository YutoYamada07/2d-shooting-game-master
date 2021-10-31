using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject,0.5f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
