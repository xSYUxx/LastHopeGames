﻿
using UnityEngine;

public class boxerInput1 : MonoBehaviour
{
  private Animator anim;

  private bool flag = true;

  void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    // ポーズ中なら実行しない
    if (!pauseManager.getPause())
    {
      // 2Pがダウンしてるときは全て無効化
      if (!boxerState.Down2)
      {
        // 左パンチ
        if (inputManager.GetDownLeft1()
          && !inputManager.GetDownRight1()
          && !boxerState.Guard2)
        {
          if (!boxerState.Left1 && !boxerState.Down1)
          {
            anim.SetBool("Left", true);
            soundManager.Instance.PlaySE(5);
          }
        }
        else { anim.SetBool("Left", false); }

        // 右パンチ
        if (inputManager.GetDownRight1()
          && !inputManager.GetDownLeft1()
          && !boxerState.Guard2)
        {
          if (!boxerState.Right1 && !boxerState.Down1)
          {
            anim.SetBool("Right", true);
            soundManager.Instance.PlaySE(4);
          }
        }
        else { anim.SetBool("Right", false); }

        // ガード
        if (inputManager.GetDownLeft1()
          && inputManager.GetDownRight1())
        {
          anim.SetBool("Guard", true);
        }
        else { anim.SetBool("Guard", false); }

        // カウンター
        if (inputManager.GetDownLeft1()
          || inputManager.GetDownRight1())
        {
          if (boxerState.Guard2)
          {
            anim.SetBool("CounterRight", true);
          }
        }
        else { anim.SetBool("CounterRight", false); }

        // ダウン
        if (hpManager.hp1 <= 0.0f)
        {
          if (flag)
          {
            anim.SetBool("Down", true);
            soundManager.Instance.PlaySE(8);
            countManager.downCount1++;
            flag = false;
          }
        }
        else { anim.SetBool("Down", false); flag = true; }
      }
    }
  }
}
