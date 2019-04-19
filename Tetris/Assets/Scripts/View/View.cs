using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DoTween

/// <summary>
/// 视图层
/// </summary>
public class View : MonoBehaviour {

    private RectTransform logoName; // 游戏名
    private RectTransform menuUI; // 菜单
    private RectTransform gameUI; // 游戏界面 UI
    private GameObject restartBtn; // 重新开始游戏按钮

	void Awake () {
        logoName = transform.Find("Canvas/LogoName") as RectTransform;
        menuUI = transform.Find("Canvas/MenuUI") as RectTransform;
        gameUI = transform.Find("Canvas/GameUI") as RectTransform;
        restartBtn = transform.Find("Canvas/MenuUI/BtnRestart").gameObject;
	}

    /// <summary>
    /// 显示菜单
    /// </summary>
    public void ShowMenu()
    {
        // 游戏名字
        logoName.gameObject.SetActive(true); // 启用
        // DOAnchorPos(Vector2 to, float duration, bool snapping); 移动到指定位置，以锚点为基准
        logoName.DOAnchorPosY(-76f, 0.5f);

        // 下方菜单
        menuUI.gameObject.SetActive(true); // 启用
        menuUI.DOAnchorPosY(59.5f, 0.5f);
    }

    /// <summary>
    /// 隐藏菜单
    /// </summary>
    public void HideMenu()
    {
        // OnComplete - 动画完成时回调
        //transform.DOMove(Vector3.one, 2).OnComplete(() => { print("代码逻辑"); }); // Lambda 表达式
        logoName.DOAnchorPosY(60f, 0.5f).OnComplete(() => {
            logoName.gameObject.SetActive(false);
        });
        menuUI.DOAnchorPosY(-59f, 0.5f).OnComplete(() => {
            menuUI.gameObject.SetActive(false);
        });
    }

    /// <summary>
    /// 显示游戏界面
    /// </summary>
    public void ShowGameUI()
    {
        gameUI.gameObject.SetActive(true);
        gameUI.DOAnchorPosY(-93f, 0.5f);
    }

    /// <summary>
    /// 隐藏游戏界面
    /// </summary>
    public void HideGameUI()
    {
        gameUI.DOAnchorPosY(94f, 0.5f).OnComplete(() => {
            gameUI.gameObject.SetActive(false);
        });
    }

    /// <summary>
    /// 显示重新开始游戏按钮
    /// </summary>
    public void ShowRestartButton()
    {
        restartBtn.SetActive(true); // 激活按钮
    }
}
