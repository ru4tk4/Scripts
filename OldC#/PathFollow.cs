using UnityEngine;
using System.Collections;

namespace Boss
{
    public class PathFollow : MonoBehaviour
    {

       /* public Path path;
        public float speed = 0.1f;
        public float mass = 5f;
        public bool isLooping = true;*/
        private float curSpeed;
        private int curPathIndex;
        private float pathLength;
        private Vector3 targetPosition;
        private Vector3 curVelocity;
        private BasicBoss self;


        // Use this for initialization
        void Start()
        {
            self = gameObject.GetComponent<BasicBoss>();
            pathLength = self.selfpatrol.path.Length;

            curPathIndex = 0;

            curVelocity = transform.forward;
        }

        // Update is called once per frame
        void Update()
        {
            curSpeed = self.selfpatrol.speed * Time.deltaTime;
            self.m_Ani.SetInteger("Path", 1);
            targetPosition = self.selfpatrol.path.GetPosition(curPathIndex);

            if (Vector3.Distance(transform.position, targetPosition) < self.selfpatrol.path.Radius)
            {
                if (curPathIndex < pathLength - 1)
                    curPathIndex++;
                else if (self.selfpatrol.isLooping)
                    curPathIndex = 0;
                else
                    return;
            }

            curVelocity += Accelerate(targetPosition);

            transform.position += curVelocity;
            transform.rotation = Quaternion.LookRotation(curVelocity);
        }

        public Vector3 Accelerate(Vector3 target)
        {
            Vector3 desiredVelocity = target - transform.position;
            desiredVelocity.Normalize();
            desiredVelocity *= curSpeed;

            Vector3 sterringForce = desiredVelocity - curVelocity;
            Vector3 acceleration = sterringForce / self.selfpatrol.mass;

            return acceleration;
        }
    }
}
