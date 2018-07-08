using System.Collections;
using System.Collections.Generic;
using Pure.Components;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Pure.Systems
{
    public class PlayerMovementSystem : JobComponentSystem
    {
        private struct PlayerMovementJob : IJobProcessComponentData<Speed, PlayerInput, Position> {

            public float DeltaTime;

            public void Execute(ref Speed speed, ref PlayerInput input, ref Position position) {
                position.Value.x += speed.Value * input.Horizontal * DeltaTime;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps) {

            var job = new PlayerMovementJob {
                DeltaTime = Time.deltaTime
            };

            return job.Schedule(this, 64, inputDeps);
        }

    }

}