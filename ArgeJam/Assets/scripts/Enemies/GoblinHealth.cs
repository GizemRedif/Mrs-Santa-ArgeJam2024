using UnityEngine;
using System.Collections;
public class GoblinHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private Animator anim;
    private bool death = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Hurt();
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Hurt()
    {
        if (death == false)
        {
            anim.SetTrigger("hurt");
        }
    }
    public void Die()
    {
        if (death == false)
        {
            anim.SetTrigger("death");
            GoblinAI goblinAI=gameObject.GetComponent<GoblinAI>();
            goblinAI.enabled = false;
            this.enabled = false;
            Destroy(gameObject, 2f);
            death = true;
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
