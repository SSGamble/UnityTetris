using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 菜单状态
/// </summary>
public class MenuState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Menu; // 指定 stateID
        AddTransition(Transition.StartButtonClick, StateID.Play); // 状态的转换
    }

    /// <summary>
    /// 进入状态的时候会调用
    /// </summary>
    public override void DoBeforeEntering()
    {
        controller.view.ShowMenu(); // 显示菜单
        controller.cameraManager.ZoomOut(); // 缩小相机视野
    }

    /// <summary>
    /// 离开状态的时候会调用
    /// </summary>
    public override void DoBeforeLeaving()
    {
        controller.view.HideMenu(); // 隐藏菜单
    }

    /// <summary>
    /// 开始按钮点击事件
    /// </summary>
    public void OnStartButtonBlick()
    {
        fsm.PerformTransition(Transition.StartButtonClick); // 切换状态
    }
}
