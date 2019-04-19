using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 继承自：FSMState，实现抽象方法
/// </summary>
public class GameOverState : FSMState
{
    private void Awake()
    {
        stateID = StateID.GameOver; // 指定 stateID
    }
}
