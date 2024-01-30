using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame
{
    public class PGDoor : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private Transform previousRoom;
        [SerializeField] private Transform nextRoom;
        [SerializeField] private PGCameraFollow cameraFollow;
        #endregion
        #region Private Methods
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                if(collision.transform.position.x < transform.position.x)
                {
                    cameraFollow.MoveToNextRoom(nextRoom);
                }
                else
                {
                    cameraFollow.MoveToNextRoom(previousRoom);
                }
            }
        }
        #endregion
    }
}
