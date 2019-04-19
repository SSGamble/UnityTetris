using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 暂停状态
/// </summary>
public class PauseState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Pause; // 指定 stateID
    }
}