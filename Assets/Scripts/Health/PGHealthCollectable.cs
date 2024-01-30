using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame
{
    public class PGHealthCollectable : MonoBehaviour
    {
        [SerializeField] private float healthValue;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                collision.GetComponent<PGPlayerHealth>().AddHealth(healthValue);
                gameObject.SetActive(false);
            }
        }
    }
}
