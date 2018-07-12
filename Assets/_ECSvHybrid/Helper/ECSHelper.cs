using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


/// <summary>
/// This is going to be used while we're debugging how ECS & the Entity system is working
/// Right now i'm trying to determine how we can catalog what entities exist, how do we iterate through them?
/// Can we pick specific entities? This will let me figure out how we get the camera referencing the player/whatever obj we want.
/// </summary>
namespace Pure.Helper
{
    public class ECSHelper : MonoBehaviour {
        public EntityManager EntityManager;

        private void Start() {
            EntityManager = World.Active.GetOrCreateManager<EntityManager>();
        }


        private void Update()
        {
            Debug.Log(string.Format("ECSHelper running...."));
            //EntityList();
        }

        //Get the list of entities we know about
        void EntityList() {
            var entities = EntityManager.GetAllEntities();

            Debug.Log(string.Format("There are {0} entities currently", entities.Length));

            foreach (var entity in entities) {
                Debug.Log(string.Format("Entity: Entity #{0}", entity.Index));
            }
        }

    }

}