using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    private bool hasBeenHit = false;

    public KeyCode keyToPress;
    public KeyCode secondKeyToPress;

    public AudioSource slashSound;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    public Animator characterAnimator;
    private bool isAttacking = false;

    public MonsterObjectLeft monster;

    void Update()
    {
        if ((Input.GetKeyDown(keyToPress) || Input.GetKeyDown(secondKeyToPress)) && canBePressed && !hasBeenHit)
        {
            hasBeenHit = true;
            isAttacking = true;
            canBePressed = false;
            gameObject.SetActive(false);

            characterAnimator.SetTrigger("attack");
            slashSound.Play();
            GameManager.instance.NoteHit();

            if (transform.position.x < -1.1 || transform.position.x > -0.1)
            {
                Debug.Log("Normal Hit Left");
                GameManager.instance.NormalHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            }
            else if (transform.position.x < -0.8 || transform.position.x > -0.5)
            {
                Debug.Log("Good Hit Left");
                GameManager.instance.GoodHit();
                Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
            }
            else
            {
                Debug.Log("Perfect Hit Left");
                GameManager.instance.PerfectHit();
                Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
            }

            if (monster != null)
            {
                monster.TriggerDeath();
            }

            Invoke("ResetAttack", 0.5f);
        }
    }

    private void ResetAttack()
    {
        isAttacking = false;
        characterAnimator.SetTrigger("reset");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && !hasBeenHit)
        {
            canBePressed = false;
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            GameManager.instance.NoteMissed();

            if (monster != null)
            {
                monster.TriggerAttack();
            }
        }
    }
}
