using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObjectLeft : MonoBehaviour
{
    public Animator monsterAnimator;

    public void TriggerAttack()
    {
        monsterAnimator.SetTrigger("attack");
        Invoke("HideMonster", 1f);
    }

    public void TriggerDeath()
    {
        monsterAnimator.SetTrigger("die");
        Invoke("HideMonster", 1f);
    }

    private void HideMonster()
    {
        gameObject.SetActive(false);
    }
}
