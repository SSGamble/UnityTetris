using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制器
/// </summary>
public class Controller : MonoBehaviour {

    // 获取 Model 和 View 的引用
    [HideInInspector]
    public Model model;
    [HideInInspector]
    public View view;
    [HideInInspector]
    public CameraManager cameraManager;
    [HideInInspector]
    public GameManager gameManager;

    private FSMSystem fsm; // 状态

    private void Awake()
    {
        // 通过标签查找，获取相应的组件
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
        // 获取 Controller 上挂载的脚本引用
        cameraManager = GetComponent<CameraManager>();
        gameManager = GetComponent<GameManager>();
    }

    private void Start()
    {
        MakeFSM();
    }

    private void MakeFSM()
    {
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>(); // 得到 State 物体上挂载的所有的状态
        foreach(FSMState state in states)
        {
            fsm.AddState(state,this); // 将所有的状态添加到状态机里面
        }
        // 设置默认状态
        MenuState s = GetComponentInChildren<MenuState>(); // 获取菜单状态
        fsm.SetCurrentState(s); // 将菜单状态设置为当前状态
    }
}
