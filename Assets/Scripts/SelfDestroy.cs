using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy0",2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Destroy0() { 
    
    Destroy(gameObject);    
    }
}
