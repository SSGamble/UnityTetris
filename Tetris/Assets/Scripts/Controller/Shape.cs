using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 形状管理
/// </summary>
public class Shape : MonoBehaviour {

    private GameManager gameManager;
    private Controller controller;
    private bool isPause = false; // 方块是否暂停下落
    private float timer = 0; // 计时器
    private float stepTime = 0.2f; // 下落时间间隔，时间步长，向下移动一次的时间间隔

	void Start () {
		
	}
	
	void Update () {
        if (isPause) return;
        timer += Time.deltaTime; // 计时器递增
        if (timer > stepTime) // 判断时间间隔
        {
            timer = 0; // 计时器归零
            Fall(); // 下落
        }
	}

    /// <summary>
    /// 下落
    /// </summary>
    public void Fall()
    {
        Vector3 pos = transform.position; // 形状当前的位置
        pos.y -= 1; // 改变竖直坐标
        transform.position = pos; // 将改变后的坐标赋回给形状

        // 如果新位置不可用，下落结束，生成新的形状
        if (controller.model.IsValidMapPosition(this.transform) == false)
        {
            // 移动回去
            pos.y += 1; // 改变竖直坐标
            transform.position = pos; // 将改变后的坐标赋回给形状
            isPause = true;
            gameManager.FallDown();
            controller.model.PlaceShape(this.transform); // 将当前形状放置到地图里
        }
    }

    /// <summary>
    /// 形状的初始化
    /// </summary>
    /// <param name="color"></param>
    public void Init(Color color,Controller controller,GameManager gameManager)
    {
        // 遍历当前形状的所有子类，即所有的 Block（方块） 和 Pivot（旋转点）
        // 再改变 Block 的颜色
        foreach(Transform t in transform)
        {
            if(t.tag == "Block")
            {
                // 利用精灵渲染器改变颜色
                t.GetComponent<SpriteRenderer>().color = color;
            }
        }
        this.controller = controller;
        this.gameManager = gameManager;
    }

    /// <summary>
    /// 暂停下落
    /// </summary>
    public void PauseFall()
    {
        isPause = true;
    }
    
    /// <summary>
    /// 开始下落
    /// </summary>
    public void StartFall()
    {
        isPause = false;
    }
}
