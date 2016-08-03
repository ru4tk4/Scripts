using UnityEngine;
using System.Collections;

namespace Boss
{
    public class Path1 : MonoBehaviour
    {

        public bool showPath = true;
        public Color PathColor = Color.blue;
        public bool loop = true;
        public float Radius = 4f;
        public Transform[] wayPoints;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void Reset()
        {
            wayPoints = new Transform[GameObject.FindGameObjectsWithTag("WayPoint").Length];

            for (int cnt = 0; cnt < wayPoints.Length; cnt++)
            {
                wayPoints[cnt] = GameObject.Find("WayPoint_" + (cnt + 1).ToString()).transform;
            }
        }

        public float Length
        {
            get
            {
                return wayPoints.Length;
            }
        }

        public Vector3 GetPosition(int index)
        {
            return wayPoints[index].position;
        }

        void OnDrawGizmos()
        {
            if (!showPath) return;

            for (int i = 0; i < wayPoints.Length; i++)
            {
                if (i + 1 < wayPoints.Length)
                {
                    Debug.DrawLine(wayPoints[i].position, wayPoints[i + 1].position, PathColor);
                }
                else
                {
                    if (loop)
                    {
                        Debug.DrawLine(wayPoints[i].position, wayPoints[0].position, PathColor);
                    }
                }
            }
        }
    }
}
