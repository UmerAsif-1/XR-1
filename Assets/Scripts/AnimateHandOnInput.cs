using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;

    public GameObject followObject;
    public float followSpeed = 30f;
    public float rotateSpeed = 100f;
    public Vector3 positionoffset;
    public Vector3 rotationOffset;
    private Transform _followTarget;
    private Rigidbody _body;
    void Start()
    {
        // physcal movements
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;

        //teleport hands
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;


    }

    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
        PhysicsMove();


    }
    void PhysicsMove()
    {
        //Position
        var postionWithOffset = _followTarget.position + positionoffset;
        var distance = Vector3.Distance(postionWithOffset, transform.position);
        _body.velocity = (_followTarget.position - transform.position).normalized * followSpeed * distance;

        //Rotation
        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = _followTarget.rotation * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity =  axis * (angle* Mathf.Deg2Rad * rotateSpeed);

    }
        
   
}
