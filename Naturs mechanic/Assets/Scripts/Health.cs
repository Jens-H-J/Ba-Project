using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anime;
    private bool dead;
    private bool invulnerable;

    private void Awake()
    {
        currentHealth = startingHealth;
        anime = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y <= -30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }

    public void TakeDamage(float _damage)
    {
        if (invulnerable == false)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            StartCoroutine(HitDelay());


            if (currentHealth > 0)
            {
                anime.SetTrigger("hurt");
            }
            else
            {
                if (!dead)
                {
                    anime.SetTrigger("die");
                    GetComponent<PlayerMovement>().enabled = false;
                    dead = true;

                    StartCoroutine(TheEnd());


                }

            }
        }
    }

    public void AddHealth(float _heal)
    {
        currentHealth = Mathf.Clamp(currentHealth + _heal, 0, startingHealth);
    }

    IEnumerator TheEnd()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator HitDelay()
    {
        invulnerable = true;
        
        yield return new WaitForSeconds(1);
        invulnerable = false;

    }


  
}
