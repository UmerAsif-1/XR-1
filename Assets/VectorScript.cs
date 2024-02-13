using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VectorScript : MonoBehaviour
{
    public Transform lens;

    public Camera mainCamera;
    public Vector3 vector;
    public Vector3 final_vector;



    // Update is called once per frame
    void Update()
    {

        vector = transform.position - mainCamera.transform.position;
        final_vector = transform.position + vector;
        transform.LookAt(final_vector,lens.up);
        
    }
}
