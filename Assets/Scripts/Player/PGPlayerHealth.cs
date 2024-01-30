using PlatformGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGPlayerHealth : MonoBehaviour
{
    #region Private Variables
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {  get; private set; }
    private Animator playerAnimator;
    private bool isDead;

    [Header("IFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashed;
    private SpriteRenderer playerSprite;

    #endregion

    #region Private Methods
    private void Awake()
    {
        currentHealth = startingHealth;
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }
    internal void OnDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            playerAnimator.SetTrigger("hurt");
            StartCoroutine(Invunerability());
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
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for(int i=0;i<numberOfFlashed; i++) 
        {
            playerSprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(1);
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(1);
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);

    }
    #endregion
}
