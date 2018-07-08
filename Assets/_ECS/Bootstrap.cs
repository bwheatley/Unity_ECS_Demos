using System.Collections;
using System.Collections.Generic;
using Pure.Components;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Bootstrap : MonoBehaviour {

    public float Speed;
    public Mesh theMesh;
    public Material theMaterial;
    public EntityArchetype PlayerArchetype;

    public int EntityLimit; //How many entities to create
    private int _entityCount = 0;
    //private EntityManager entityManager = new EntityManager();

	// Use this for initialization
	void Start () {
	    Debug.Log("Started Start");
        //Create Archetypes
        CreateArcheTypes();

        CreateEntity();
	    Debug.Log("Ended Start");
	}


    //The entities are not created on start becuase you have to wait for the scene to load, this is a low budget way around it
    //See here for a better example: https://github.com/Unity-Technologies/EntityComponentSystemSamples/blob/master/TwoStickShooter/Pure/Assets/GameCode/TwoStickBootstrap.cs Line ~67
    //private void Update() {
    //    if (_entityCount < EntityLimit) {
    //        CreateEntity();
    //    }
    //}

    void CreateEntity() {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        //Example when you don't have a archetype
        //Entity playerEntity = entityManager.CreateEntity(
        //    ComponentType.Create<Speed>(),
        //    ComponentType.Create<PlayerInput>(),
        //       ComponentType.Create<Position>(),
        //       ComponentType.Create<TransformMatrix>(),
        //       ComponentType.Create<MeshInstanceRenderer>()
        //);

        //When you do have an archetype
        Entity playerEntity = entityManager.CreateEntity(PlayerArchetype);

        entityManager.SetComponentData(playerEntity, new Speed { Value = Speed });
        //entityManager.SetComponentData(playerEntity, new PlayerInput { Horizontal = Input.GetAxis("Horizontal") });

        //NOTE: you will need to have gpu instancing enabled on whatever material you pick for this
        entityManager.SetSharedComponentData(playerEntity, new MeshInstanceRenderer
            {
                mesh = theMesh,
                material = theMaterial
            }
        );

        _entityCount++;

        Debug.Log(string.Format("ENTITY Created"));

    }

    //We'll start with just 1 archetype for now
    void CreateArcheTypes() {
        Debug.Log(string.Format("Archetypes Created"));

        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        PlayerArchetype = entityManager.CreateArchetype(
            typeof(Speed),
            typeof(PlayerInput),
            typeof(Position),
            typeof(TransformMatrix),
            typeof(MeshInstanceRenderer)
        );
    }

}
