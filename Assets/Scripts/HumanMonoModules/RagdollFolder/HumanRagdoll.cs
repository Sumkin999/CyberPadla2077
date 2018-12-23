using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules.RagdollFolder
{
    public class HumanRagdoll:MonoBehaviour
    {
        public bool IsFullRagdoll;

        public List<Rigidbody> AllRigidbodies = new List<Rigidbody>();
        
        public Animator Animator;
        public Transform GodTransform;
        public Collider GodCollider;
        public Rigidbody GodRigidbody;


        public Transform ModelTransform;
        public Transform HipsTransform;
        public string NameOfGetUpFromFrontState;
        public string NameOfGetUpFromBackState;


        protected Transform MOrientTransform;
        public Transform AdditionalTransform;

        private string _getUpAnimName;

        public bool BlendInProgress;
        public float TransitionDuration;
        private float _currentBlendTime;
        private List<Transform> _allPartsTransform = new List<Transform>();
        private List<Vector3> _oPositions = new List<Vector3>();
        private List<Quaternion> _oRotations = new List<Quaternion>();
        private List<Vector3> _aPositions = new List<Vector3>();
        private List<Quaternion> _aRotations = new List<Quaternion>();

        void Start()
        {
            GameObject orientTransformObj = new GameObject("OrientTransform");
            orientTransformObj.transform.position = AllRigidbodies[1].position;
            orientTransformObj.transform.rotation = GodTransform.rotation;
            orientTransformObj.transform.SetParent(AllRigidbodies[1].transform);



            MOrientTransform = orientTransformObj.transform;


            GameObject addTransformGameObject = new GameObject("AdditionalTransform");

            AdditionalTransform = addTransformGameObject.transform;
            AdditionalTransform.parent = GodTransform;



            foreach (var bp in AllRigidbodies)
            {
                _allPartsTransform.Add(bp.transform);
                _oPositions.Add(bp.transform.position);
                _oRotations.Add(bp.transform.rotation);
                _aPositions.Add(bp.transform.position);
                _aRotations.Add(bp.transform.rotation);

                
            }
        }


        public void RagdollOn()
        {

            
            Animator.enabled = false;

            GodCollider.isTrigger = true;
            GodRigidbody.isKinematic = true;
            
            foreach (var rb in AllRigidbodies)
            {
                rb.gameObject.layer = 11;

                rb.isKinematic = false;
            }

            BlendInProgress = false;
            IsFullRagdoll = true;
        }

        //ОТЛОЖЕННЫЙ РАГДОЛЛ ОТ УДАРА
        /*public void HitReaction(List<MonoBodyPartHum> bparts, Vector3 vector3, float str)
        {
            foreach (var bp in bparts)
            {
                if (BodyParts.Contains(bp))
                {
                    if (IsFullRagdoll)
                    {
                        bp.AddForce(vector3, str);
                    }
                    else
                    {
                        bp.ThisRigidbody.isKinematic = false;
                        bp.ThisRigidbody.AddForce(vector3 * str, ForceMode.Impulse);
                        bp.ThisRigidbody.isKinematic = true;
                    }
                }
            }
        }*/


        public void RagdollOff()
        {
            
            foreach (var rb in AllRigidbodies)
            {
                rb.gameObject.layer = 12;
                rb.isKinematic = true;
            }

            GodCollider.isTrigger = false;
            GodRigidbody.isKinematic = false;

            Animator.enabled = true;

            Animator.applyRootMotion = false;
            bool upwards = MOrientTransform.forward.y <= 0.0f;

            if (upwards)
            {    
                _getUpAnimName = NameOfGetUpFromFrontState;
            }
            else
            {
                _getUpAnimName = NameOfGetUpFromBackState;
            }

            AdditionalTransform.position = MOrientTransform.position;
            AdditionalTransform.eulerAngles = MOrientTransform.eulerAngles;

            HipsTransform.parent = null;

            GodTransform.position = MOrientTransform.position;
            GodTransform.position = new Vector3(GodTransform.position.x, 0.2f, GodTransform.position.z);


            if (upwards)
            {
                GodTransform.forward = AdditionalTransform.up;
            }
            else
            {
                GodTransform.forward = -AdditionalTransform.up;
            }

            HipsTransform.parent = ModelTransform;

            
            Animator.CrossFade(_getUpAnimName, 0.0f, 3, 0.0f);
            Animator.applyRootMotion = true;

            IsFullRagdoll = false;

            BlendInic();
        }

        public void BlendInic()
        {
            for (int i = 0; i < _oRotations.Count; i++)
            {
                _oRotations[i] = _allPartsTransform[i].rotation;
            }
            for (int i = 0; i < _oPositions.Count; i++)
            {
                _oPositions[i] = _allPartsTransform[i].localPosition;
            }
            _currentBlendTime = 0;

            /*HipsTransform.parent = null;
            GodTransform.position = HipsTransform.position;
            HipsTransform.parent = ModelTransform;*/
            //HipsTransform.localPosition=

            BlendInProgress = true;
        }

        public void BlendToMecanim()
        {
            _currentBlendTime += Time.deltaTime;
            float blendAmount = _currentBlendTime / TransitionDuration;
            blendAmount = Mathf.Clamp01(blendAmount);


            for (int i = 0; i < _aRotations.Count; i++)
            {
                _aRotations[i] = _allPartsTransform[i].rotation;
            }
            for (int i = 0; i < _aPositions.Count; i++)
            {
                _aPositions[i] = _allPartsTransform[i].localPosition;
            }

            for (int i = 0; i < _allPartsTransform.Count; i++)
            {

                _allPartsTransform[i].localPosition = Vector3.Lerp(_oPositions[i], _aPositions[i], blendAmount);
                _allPartsTransform[i].rotation = Quaternion.Slerp(_oRotations[i], _aRotations[i], blendAmount);
            }

            if (_currentBlendTime >= TransitionDuration)
            {
                Debug.Log("Transition Complete!");
                BlendInProgress = false;
            }
        }

        void LateUpdate()
        {
            if (BlendInProgress)
            {
                BlendToMecanim();
            }
        }
        void Update()
        {
            if (IsFullRagdoll)
            {
                /*foreach (var bpart in BodyParts)
                {
                    bpart.PushForce();
                }*/
            }
        }
    }
}
