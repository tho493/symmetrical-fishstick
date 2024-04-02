using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDan : MonoBehaviour
{
    public float time = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, time);
    }
}
