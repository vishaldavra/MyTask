using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsUp=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUp)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 10, 0);
        }
        else {

            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 10, 0);
        }
        if (Score_And_Panels.IsGameOver) { 
        Destroy(gameObject);
        }
    }
}
