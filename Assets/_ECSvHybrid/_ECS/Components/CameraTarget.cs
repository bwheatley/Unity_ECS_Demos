using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Pure.Components
{
    public struct CameraTarget : IComponentData
    {
        //public Transform PlayerTransform;
        //public Transform CameraTransform;
        //public Vector3 offset;

        //Since we're referencing a exisiting class Component use this vs using ComponentDataArray (which allows access to
        //IComponentData)
        [ReadOnly] public ComponentArray<Camera> Camera;
        public int Length;
        public GameObjectArray GameObject;
    }

    //public class CameraTarget : MonoBehaviour
    //{
    //    public Transform PlayerTransform;
    //    public Transform CameraTransform;
    //    public Vector3 offset;

    //    //We need to make sure that the camera is always using the right offset
    //    void Awake()
    //    {
    //        offset = CameraTransform.position - PlayerTransform.position;
    //    }
    //}
}
