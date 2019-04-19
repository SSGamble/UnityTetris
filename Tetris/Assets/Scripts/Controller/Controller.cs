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
    public View view;

    private void Awake()
    {
        // 通过标签查找，获取相应的组件
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
    }
}
