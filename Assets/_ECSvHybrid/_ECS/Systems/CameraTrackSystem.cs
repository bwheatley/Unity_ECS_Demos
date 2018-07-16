using System.Collections;
using System.Collections.Generic;
using Pure.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Pure.Systems
{
    //public class CameraTrackSystem : JobComponentSystem
    //{

    //    private struct CameraTrackJob : IJobProcessComponentData<CameraTarget> {

    //        public void Execute(ref CameraTarget cameraData) {
    //            cameraData.CameraTransform.position = cameraData.PlayerTransform.position + cameraData.offset;
    //        }
    //    }

    //    protected override JobHandle OnUpdate(JobHandle inputDeps) {

    //        Debug.Log("CameraTrackSystem Run");

    //        var job = new CameraTrackJob {

    //        };

    //        return job.Schedule(this, 64, inputDeps);
    //    }
    //} 

    /// <summary>
    /// Just reusing the same implementation we did for the hybrid system. I couldn't
    /// figure out a way to work with the camera in the jobs system w/o getting
    /// "ArgumentException: Pure.Components.CameraTarget is an IComponentData, and thus must be blittable (No managed object is allowed on the struct)."
    /// </summary>
    public class CameraTrackSystem : ComponentSystem
    {
        public struct Group
        {
            //I couldn't figure out how this works
            //public CameraTarget CameraTarget;


            //NOTE ALL The does says use [ReadOnly] but for length it's readonly as you see below not [Readonly]
            [ReadOnly] public ComponentArray<Camera> Camera;
            public readonly int Length;
            public GameObjectArray GameObject;
        }

        [Inject] private Group m_Group;

        protected override void OnUpdate()
        {
            Debug.Log(string.Format("CameraTrackSystem Running ..."));

            //Debug.Log(string.Format("Group {0}", m_Group.CameraTarget.Length));
            Debug.Log(string.Format("Group Length {0}", m_Group.Length));

            for (int i = 0; i < m_Group.Length; i++) {
                var _localCam = m_Group.GameObject[i];

                //Debug.Log(string.Format("Iteration {0} Item {1}", i, m_Group.GameObject[i].name));
                Debug.Log(string.Format("Iteration {0} Item {1}", i, _localCam));
                _localCam.transform.position = 
                //entity.CameraTarget.CameraTransform.position =
                //    entity.CameraTarget.PlayerTransform.position + entity.CameraTarget.offset;

            }


        }
        //protected override void OnUpdate()
        //{
        //    foreach (var entity in GetEntities<Group>())
        //    {
        //        entity.CameraTarget.CameraTransform.position =
        //            entity.CameraTarget.PlayerTransform.position + entity.CameraTarget.offset;
        //    }
        //}
    }
}
