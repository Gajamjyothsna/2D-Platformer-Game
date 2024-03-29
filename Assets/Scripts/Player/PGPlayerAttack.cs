using UnityEngine;

namespace PlatformGame
{
    public class PGPlayerAttack : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private float attackCooldown;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject[] fireballs;

        private Animator anim;
        private PGPlayerMovement playerMovement;
        private float cooldownTimer = Mathf.Infinity;
        #endregion

        #region Private Methods
        private void Awake()
        {
            anim = GetComponent<Animator>();
            playerMovement = GetComponent<PGPlayerMovement>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
                Attack();

            cooldownTimer += Time.deltaTime;
        }

        private void Attack()
        {
            anim.SetTrigger("attack");
            cooldownTimer = 0;

            fireballs[FindFireball()].transform.position = firePoint.position;
            fireballs[FindFireball()].GetComponent<PGProjectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
        private int FindFireball()
        {
            for (int i = 0; i < fireballs.Length; i++)
            {
                if (!fireballs[i].activeInHierarchy)
                    return i;
            }
            return 0;
        }
        #endregion
    }
}