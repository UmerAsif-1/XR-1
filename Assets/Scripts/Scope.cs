using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    
   
   public Animator animator;

   public GameObject  scopeOverlay;
   
   public GameObject WeaponCamera;

   public Camera MainCamera;

   public float scopedFOV = 15f;

   private float normalFOV;

   private bool isScoped = false;
   void update(){
    if (Input.GetButtonDown("Fire2"))
    {
        isScoped = !isScoped;
        animator.SetBool("Scoped" , isScoped);

        if (isScoped)
         StartCoroutine(OnScoped());
        else OnUnscoped ();

    }
   }
   void OnUnscoped(){
    scopeOverlay.SetActive(false);
    WeaponCamera.SetActive(true);
    MainCamera.fieldOfView = normalFOV;
   }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        WeaponCamera.SetActive(false);

        normalFOV = MainCamera.fieldOfView;
        MainCamera.fieldOfView = scopedFOV;


    }
}

