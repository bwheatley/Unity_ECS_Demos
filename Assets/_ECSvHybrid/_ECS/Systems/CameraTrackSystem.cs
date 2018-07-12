using System.Collections;
using System.Collections.Generic;
using Pure.Components;
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
            public CameraTarget CameraTarget;
        }

        [Inject] private Group m_Group;

        protected override void OnUpdate()
        {
            Debug.Log(string.Format("CameraTrackSystem Running ..."));

            Debug.Log(string.Format("Group {0}", m_Group.CameraTarget.Length));

            //foreach (var item in m_Group)
            //{

            //}

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
