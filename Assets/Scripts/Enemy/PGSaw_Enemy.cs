using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame
{
    public class PGSaw_Enemy : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float movementDistance;
        [SerializeField] private float speed;
        private float leftEdge;
        private float rightEdge;
        private bool isMovingLeft;

        private void Awake()
        {
            leftEdge = transform.position.x - movementDistance;
            rightEdge = transform.position.x + movementDistance;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(isMovingLeft)
            {
                if(transform.position.x > leftEdge)
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);    
                }
                else
                {
                    isMovingLeft = false;
                }
            }
            else
            {
                if(transform.position.x < rightEdge)
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

                }
                else
                {
                    isMovingLeft = true;
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                collision.GetComponent<PGPlayerHealth>().OnDamage(damage);
            }
        }
    }
}
