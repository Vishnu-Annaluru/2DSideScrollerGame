using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public Image healthBar;
    public float healthAmount = 100f;
    bool run = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((healthBar.fillAmount <= 0) || (healthAmount <= 0))
        {
            Destroy(gameObject);
        }
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.left * 5 * Time.deltaTime);
            run = true;
            animator.SetBool("walk", run);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.right * 5 * Time.deltaTime);
            //transform.localScale = transform.localScale * -1f;
            run = true;
            animator.SetBool("walk", run);

        }
        else
        {
            run = false;
            animator.SetBool("walk", run);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
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
        TakeDamage(5);
    }
    
}
