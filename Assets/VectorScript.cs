using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VectorScript : MonoBehaviour
{
    public Camera lensCamera;

    public Camera mainCamera;
    public Vector3 vector;
    public Vector3 final_vector;



    // Update is called once per frame
    void Update()
    {

        vector = lensCamera.transform.position - mainCamera.transform.position;
        final_vector = lensCamera.transform.position + vector;
        lensCamera.transform.LookAt(final_vector);
        
    }
}