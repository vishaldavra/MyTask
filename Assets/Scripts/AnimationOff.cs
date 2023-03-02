using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOff : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> AnimyParents;
    void Start()
    {
        for (int i = 0; i < AnimyParents.Count; i++) {

            AnimyParents[i].GetComponent<Animator>().enabled = false;   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
