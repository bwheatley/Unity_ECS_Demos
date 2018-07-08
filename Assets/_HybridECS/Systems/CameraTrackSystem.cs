using System.Collections;
using System.Collections.Generic;
using Hybrid.Components;
using UnityEngine;
using Unity.Entities;

namespace Hybrid.Systems
{
    public class CameraTrackSystem : ComponentSystem
    {
        private struct Group {
            public CameraTarget CameraTarget;
        }


        protected override void OnUpdate() {
            foreach (var entity in GetEntities<Group>()) {
                entity.CameraTarget.CameraTransform.position =
                    entity.CameraTarget.PlayerTransform.position + entity.CameraTarget.offset;
            }
        }
    }

}