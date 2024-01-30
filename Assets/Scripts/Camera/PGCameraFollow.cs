using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame
{
    public class PGCameraFollow : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private float speed;
        private float currentPosX; 
        private Vector3 velocity = Vector3.zero;

        //Follow Player
        [SerializeField] private Transform player;
        [SerializeField] private float aheadDistance;
        [SerializeField] private float cameraSpeed;
        private float lookAhead;
        #endregion

        #region Private Methods

        // Update is called once per frame
        void Update()
        {
            //Room Camera
            // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed );

            //follow player
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        }
        internal void MoveToNextRoom(Transform _nextRoom)
        {
            currentPosX = _nextRoom.position.x; 
        }

        #endregion
    }
}
