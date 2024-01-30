using PlatformGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGPlayerHealth : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private float startingHealth;
    public float currentHealth {  get; private set; }
    private Animator playerAnimator;
    private bool isDead;
    #endregion

    #region Private Methods
    private void Awake()
    {
        currentHealth = startingHealth;
        playerAnimator = GetComponent<Animator>();
    }
    internal void OnDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            playerAnimator.SetTrigger("hurt");
            //IFrames
        }
        else
        {
            if(!isDead)
            {
                //player dead
                playerAnimator.SetTrigger("dead");
                GetComponent<PGPlayerMovement>().enabled = false;
                isDead = true;
            }
           
        }
    }
    internal void AddHealth(float healthValue)
    {
        currentHealth = Mathf.Clamp(currentHealth + healthValue, 0, startingHealth);

    }
    #endregion
}
