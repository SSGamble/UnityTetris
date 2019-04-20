using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 模型层
///     保存了地图数据，用于判断哪些地方有方块，哪些地方没有方块
/// </summary>
public class Model : MonoBehaviour {

    // 整个地图的行数和列数
    private const int MAX_ROW = 23; // 增加 3 行，是为了，在方块铺满屏幕的时候，判断顶部新生成的形状
    private const int MAX_COLUMN = 9;

    // 位置数组，用于保存整张地图的位置信息
    private Transform[,] map = new Transform[MAX_ROW, MAX_COLUMN];

    /// <summary>
    /// 判断地图位置是否能用
    ///  - 是否在地图内
    ///  - 当前位置是否有别的图形
    /// </summary>
    /// <returns></returns>
    public bool IsValidMapPosition(Transform t)
    {
        // 遍历所有孩子的位置
        foreach (Transform child in t)
        {
            if (child.tag != "Block") continue; // 如果不是方块，不做操作，直接遍历下一个
            // 是方块
            Vector2 pos = child.position.Round(); // 坐标转换，取整
            if (!IsInsideMap(pos)) return false; // 如果不在地图内，false
            // print(pos.x + " " + pos.y);
            if (map[(int)pos.x, (int)pos.y] != null) return false; // 如果该位置有图形，不可用
        }
        return true; // 可用
    } 

    /// <summary>
    /// 是否在地图内
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private bool IsInsideMap(Vector2 pos)
    {
        // 不能超过左右边界和下边界
        return pos.x >= 0 && pos.x < MAX_COLUMN && pos.y >= 0;
    }

    /// <summary>
    /// 将形状放置到地图里
    /// </summary>
    /// <param name="t"></param>
    public void PlaceShape(Transform t)
    {
        // 遍历所有孩子的位置
        foreach (Transform child in t)
        {
            if (child.tag != "Block") continue; // 如果不是方块，不做操作，直接遍历下一个
            // 是方块
            Vector2 pos = child.position.Round(); // 坐标转换，取整
            map[(int)pos.x, (int)pos.y] = child; // 放到地图里
        }
    }
}
