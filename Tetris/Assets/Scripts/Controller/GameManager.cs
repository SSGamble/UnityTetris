using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool isPause = true; // 游戏是否暂停
    public Shape[] shapes; // 形状数组
    public Color[] colors; // 颜色数组
    private Shape currentShape = null; // 当前图形，用于判断是否生成新的图形
    private Controller controller; // 控制器的引用

    private void Awake()
    {
        controller = GetComponent<Controller>();
    }

    void Start () {
		
	}
	
	void Update () {
        if (isPause) return;
        // 如果当前图形为空，则生成一个新的形状
        if (currentShape == null) 
        {
            SpawnShape();
        }
	}

    /// <summary>
    /// 开始游戏
    /// </summary>
    public void StartGame()
    {
        isPause = false;
        // 开始当前形状的下落
        if (currentShape != null)
        {
            currentShape.StartFall();
        }
    }

    /// <summary>
    /// 暂停游戏
    /// </summary>
    public void PauseGame()
    {
        // 暂停游戏
        isPause = true;
        // 停止当前形状的下落
        if(currentShape != null)
        {
            currentShape.PauseFall();
        }
    }

    /// <summary>
    /// 生成图形
    /// </summary>
    public void SpawnShape()
    {
        // 随机一个形状和颜色
        int shapeIndex = Random.Range(0, shapes.Length);
        int colorIndex = Random.Range(0, colors.Length);
        // 生成形状
        currentShape = GameObject.Instantiate(shapes[shapeIndex]);
        currentShape.Init(colors[colorIndex],controller,this);
    }

    /// <summary>
    /// 方块落下来了,将当前方块置空
    /// </summary>
    public void FallDown()
    {
        currentShape = null;
    }
}
