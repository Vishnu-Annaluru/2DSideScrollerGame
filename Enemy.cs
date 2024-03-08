using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public GameObject player;
    public Image healthBar;
    public float healthAmount = 100f;
    bool run = false;
    float t = 0f;
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if ((healthBar.fillAmount <= 0) || (healthAmount <=0))
        {
            Destroy(gameObject);
        }


        Debug.Log(healthBar.fillAmount + " " + healthAmount);
        t+=Time.deltaTime;
        if(Mathf.Abs(transform.position.x - player.transform.position.x)< 3)
        {
            if(t > 2f)
            {
                animator.SetTrigger("attack");
                t = 0f;
            }
        }

        if(Mathf.Abs(transform.position.x - player.transform.position.x) > 4)
        {
            run = true;
            transform.Translate(Vector3.left * 2 * Time.deltaTime);
            animator.SetBool("walk", run);
        }
        else
        {
            run = false;
            animator.SetBool("walk", run);
            
        }


    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("hit");
        TakeDamage(10);
    }
}
