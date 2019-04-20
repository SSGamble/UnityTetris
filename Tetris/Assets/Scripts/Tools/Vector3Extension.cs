using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vector3 的扩展方法
/// </summary>
public static class Vector3Extension {

    /// <summary>
    /// 将 V3 转换为 V2，并对 x,y 坐标进行取整
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
	public static Vector2 Round(this Vector3 v)
    {
        // 对 x，y 坐标进行取整
        int x = Mathf.RoundToInt(v.x);
        int y = Mathf.RoundToInt(v.y);
        return new Vector2(x, y);
    }
}
