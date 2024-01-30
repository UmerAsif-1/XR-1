using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lt : MonoBehaviour
{
    public Light light;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
    light = GetComponent<Light> (); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            light.color = Color.red;
        }
    }
}