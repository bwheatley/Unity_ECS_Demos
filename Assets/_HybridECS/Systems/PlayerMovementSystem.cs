using System;
using Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace Hybrid.Systems
{
    public class PlayerMovementSystem : ComponentSystem
    {

        private struct Group {
            public Transform Transform;
            public PlayerInput PlayerInput;
            public Speed Speed;
        }


        protected override void OnUpdate() {

            foreach (var entity in GetEntities<Group>()) {
                var position = entity.Transform.position;
                var rotation = entity.Transform.rotation;

                position.x += entity.Speed.Value * entity.PlayerInput.Horizontal * Time.deltaTime;
                rotation.w = Mathf.Clamp(entity.PlayerInput.Horizontal, -0.5f, 0.5f);

                entity.Transform.position = position;
                entity.Transform.rotation = rotation;
            }
        }
    }

}