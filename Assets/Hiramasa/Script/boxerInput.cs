﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boxerInput : MonoBehaviour
{
  private Animator animator;

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (Input.GetButtonDown("1PTalconghaRight"))
    {
      animator.SetBool("RightPunch", true);
    }
    else
    {
      animator.SetBool("RightPunch", false);
    }
  }
}
