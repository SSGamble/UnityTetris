using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DoTween

public class CameraManager : MonoBehaviour {

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main; // 获取主摄像机
    }

    void Start () {
		
	}
	
	void Update () {
		
	}

    /// <summary>
    /// 放大
    /// </summary>
    public void ZoomIn()
    {
        mainCamera.DOOrthoSize(13, 0.5f); // 改变相机正交大小
    }

    /// <summary>
    /// 缩小
    /// </summary>
    public void ZoomOut()
    {
        mainCamera.DOOrthoSize(17, 0.5f); // 改变相机正交大小
    }
}
