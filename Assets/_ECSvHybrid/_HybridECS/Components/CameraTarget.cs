using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hybrid.Components
{
    public class CameraTarget : MonoBehaviour {
        public Transform PlayerTransform;
        public Transform CameraTransform;
        public Vector3 offset;

        //We need to make sure that the camera is always using the right offset
        void Awake()
        {
            offset = CameraTransform.position - PlayerTransform.position;      
        }
    }
}
