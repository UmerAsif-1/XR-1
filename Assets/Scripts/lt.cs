using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lt : MonoBehaviour
{
    public Light targetlight;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
    targetlight = GetComponent<Light> (); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            targetlight.color = Color.red;
        }
    }
}