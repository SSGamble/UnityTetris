using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏状态
/// </summary>
public class PlayState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Play; // 指定 stateID
        AddTransition(Transition.PauseButtonClick, StateID.Menu); // 状态转移
    }

    /// <summary>
    /// 进入状态的时候会调用
    /// </summary>
    public override void DoBeforeEntering()
    {
        controller.view.ShowGameUI(); // 显示游戏界面
        controller.cameraManager.ZoomIn(); // 放大视野
    }

    /// <summary>
    /// 离开状态的时候会调用
    /// </summary>
    public override void DoBeforeLeaving()
    {
        controller.view.HideGameUI(); // 隐藏游戏界面
        controller.view.ShowRestartButton(); // 显示重新开始按钮
    }

    /// <summary>
    /// 暂停按钮，点击事件
    /// </summary>
    public void OnPauseButtonClick()
    {
        fsm.PerformTransition(Transition.PauseButtonClick); // 切换状态
    }
}