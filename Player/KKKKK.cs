using UnityEngine;
using System.Collections;



public static class KKKKK  {

    /// <summary>
    /// 去掉三维向量的Y轴，把向量投射到xz平面。
    /// </summary>
    /// <param name="vector3"></param>
    /// <returns></returns>
    public static Vector2 IgnoreYAxis(this Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.z);
    }

    /// <summary>
    /// 求点到直线的距离，采用数学公式Ax+By+C = 0; d = A*p.x + B * p.y + C / sqrt(A^2 + B ^ 2)
    /// 此算法忽略掉三维向量的Y轴，只在XZ平面进行计算，适用于一般3D游戏。
    /// </summary>
    /// <param name="startPoint">向量起点</param>
    /// <param name="endPoint">向量终点</param>
    /// <param name="point">待求距离的点</param>
    /// <returns></returns>
    public static float DistanceOfPointToVector(Vector3 startPoint, Vector3 endPoint, Vector3 point)
    {
        Vector2 startVe2 = startPoint.IgnoreYAxis();

        Vector2 endVe2 = endPoint.IgnoreYAxis();

        float A = endVe2.y - startVe2.y;

        float B = startVe2.x - endVe2.x;

        float C = endVe2.x * startVe2.y - startVe2.x * endVe2.y;

        float denominator = Mathf.Sqrt(A * A + B * B);

        Vector2 pointVe2 = point.IgnoreYAxis();

        return Mathf.Abs((A * pointVe2.x + B * pointVe2.y + C) / denominator); ;
    }

    public static void FollowTarget(Transform Object ,Transform target)
    {

    }
    
}
