using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.HumanMonoModules
{
    public class TransformModule:MonoBehaviour
    {
        public AnimatorModule AnimatorModule;


        public Transform MainTransform;
        public Rigidbody RigidbodyMain;



        public bool PathFindIsOn;
        public Vector3 MoveTargetVector3;
        private Vector3 _previousMoveTargetVector3;

        public float MoveSpeed;
        public float RunSpeedModifier=1;
        public Seeker Seeker;
        public Path CurrentPath;
        private float nextWaypointDistance = 3;
        private int currentWaypoint = 0;
        //private bool reachedEndOfPath;
        private float distanceToWaypoint;

        public Vector3 LookAtVector3;

        public float VelocitySmooth = 10;
        public float RotationSpeed = 180f;

        private Vector3 _localTarget;
        private Vector3 _lastPosition;
        private float _timerLastPosition;
        [Space(40)]
        public Transform PathFindTransform;
        public GameObject TEMP_AI_TARGET;

        public void Move()
        {
            
            RigidbodyMain.MovePosition(MainTransform.position + _localTarget.normalized * Time.deltaTime * MoveSpeed*RunSpeedModifier);
            
        }


        public void FreeMovePrepare()
        {
            MoveTargetVector3 -= MainTransform.position;
            MoveTargetVector3.Normalize();
            _localTarget = MoveTargetVector3;

            PathFindTransform.position = MainTransform.position;
            PathFindTransform.parent = null;
        }

        public void PathFindMovePrepare()
        {
            MoveTargetVector3 = PathFindTransform.position;
            Seeker.StartPath(MainTransform.position, MoveTargetVector3, OnPathComplete);
            if (CurrentPath == null)
            {
                Debug.Log("Path is null");
                
                // We have no path to follow yet, so don't do anything
                return;
            }
            while (true)
            {
                // If you want maximum performance you can check the squared distance instead to get rid of a
                // square root calculation. But that is outside the scope of this tutorial.
                distanceToWaypoint = Vector3.Distance(MainTransform.position, CurrentPath.vectorPath[currentWaypoint]);
                if (distanceToWaypoint < nextWaypointDistance)
                {
                    // Check if there is another waypoint or if we have reached the end of the path
                    if (currentWaypoint + 1 < CurrentPath.vectorPath.Count)
                    {
                        currentWaypoint++;
                    }
                    else
                    {
                        // Set a status variable to indicate that the agent has reached the end of the path.
                        // You can use this to trigger some special code if your game requires that.
                        //TODO
                        //reachedEndOfPath = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

                //_localTarget = CurrentPath.vectorPath[currentWaypoint] - MainTransform.position;
            }




            
            //MoveTargetVector3 -= MainTransform.position;
            MoveTargetVector3 = CurrentPath.vectorPath[currentWaypoint] - MainTransform.position;
            MoveTargetVector3.Normalize();
            _localTarget = MoveTargetVector3;
        }
        #region PathFindRegion
        private void OnPathComplete(Path p)
        {
            Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
            if (!p.error)
            {
                CurrentPath = p;
                // Reset the waypoint counter so that we start to move towards the first point in the path
                currentWaypoint = 0;
            }
        }

        /*public void MovePathControl()
        {
            
            _previousMoveTargetVector3 = MoveTargetVector3;

            _localTarget = MoveTargetVector3;

            if (PathFindIsOn)
            {
                MoveTargetVector3 = TEMP_AI_TARGET.transform.position;
                _localTarget = MoveTargetVector3;
                
                if (Vector3.Distance(MoveTargetVector3, _previousMoveTargetVector3) > .5f)
                {
                    Seeker.StartPath(MainTransform.position, MoveTargetVector3, OnPathComplete);
                }
                if (CurrentPath == null)
                {
                    // We have no path to follow yet, so don't do anything
                    return;
                }
                // Check in a loop if we are close enough to the current waypoint to switch to the next one.
                // We do this in a loop because many waypoints might be close to each other and we may reach
                // several of them in the same frame.
                //TODO
                //reachedEndOfPath = false;
                // The distance to the next waypoint in the path

                while (true)
                {
                    // If you want maximum performance you can check the squared distance instead to get rid of a
                    // square root calculation. But that is outside the scope of this tutorial.
                    distanceToWaypoint = Vector3.Distance(MainTransform.position, CurrentPath.vectorPath[currentWaypoint]);
                    if (distanceToWaypoint < nextWaypointDistance)
                    {
                        // Check if there is another waypoint or if we have reached the end of the path
                        if (currentWaypoint + 1 < CurrentPath.vectorPath.Count)
                        {
                            currentWaypoint++;
                        }
                        else
                        {
                            // Set a status variable to indicate that the agent has reached the end of the path.
                            // You can use this to trigger some special code if your game requires that.
                            //TODO
                            //reachedEndOfPath = true;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                //if (!reachedEndOfPath)
                {
                    _localTarget = CurrentPath.vectorPath[currentWaypoint] - MainTransform.position;
                }
                
                

            }
            else
            {

            }
        }
        private void OnPathComplete(Path p)
        {
            Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
            if (!p.error)
            {
                CurrentPath = p;
                // Reset the waypoint counter so that we start to move towards the first point in the path
                currentWaypoint = 0;
            }
        }*/



        #endregion



        public void MoveAnimationControl()
        {
            
            if (_timerLastPosition<=0)
            {
                
                _lastPosition = MainTransform.position;
                _timerLastPosition = 0.2f;
            }

            Vector3 reletiveVelocity = _lastPosition - MainTransform.position;// _localTarget - MainTransform.position;
            reletiveVelocity.Normalize();
            reletiveVelocity = MainTransform.InverseTransformVector(-reletiveVelocity);
            _timerLastPosition -= Time.deltaTime;


            AnimatorModule.SetWalkBlendDirection(reletiveVelocity, VelocitySmooth);
        }


        public void Rotate()
        {
            MainTransform.rotation = Quaternion.Lerp(MainTransform.rotation, Quaternion.AngleAxis(GetAngle(LookAtVector3), Vector3.up), Time.deltaTime * RotationSpeed);
            //MainTransform.LookAt(new Vector3(LookAtVector3.x,MainTransform.position.y,LookAtVector3.z));
        }
        private float GetAngle(Vector3 target)
        {
            Vector3 targetVector = (target - transform.position + transform.forward * 0.3f).normalized;
            float angle = -Vector2.SignedAngle(Vector2.up, new Vector2(targetVector.x, targetVector.z));
            return angle;
        }
    }
}
