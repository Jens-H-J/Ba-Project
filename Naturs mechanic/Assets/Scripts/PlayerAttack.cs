using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anime;
    private PlayerMovement playerMovement;

    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBall;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anime = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
       {
           Attack();
       }

        cooldownTimer += Time.deltaTime;

    }

    private void Attack()
    {
        anime.SetTrigger("attack");
        cooldownTimer = 0;

        //objectpooling
        fireBall[FindFireball()].transform.position = firePoint.position;
        fireBall[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private int FindFireball()
    {
        for (int i = 0; i < fireBall.Length; i++)
        {
            if (!fireBall[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
