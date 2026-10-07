using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    protected Health health;
    protected Collider characterCollider;
    [SerializeField]
    protected Animator characterAnimator;
    protected virtual void Awake()
    {
        health = GetComponent<Health>();
        characterCollider = GetComponent<Collider>();
    }
    public virtual void Die()
    {
        characterCollider.enabled = false;
        StartCoroutine(DieCoroutine());
    }
    private IEnumerator DieCoroutine()
    {
        characterAnimator.Play("Death", 0, 0f);
        yield return characterAnimator.WaitForCurrentAnimation();
        //yield return StartCoroutine(blinkCharacterCoroutine());
        gameObject.SetActive(false);
    }
    private IEnumerator blinkCharacterCoroutine()
    {
        float blinkDuration = 0.1f;
        int blinkCount = 5;
        for (int i = 0; i < blinkCount; i++)
        {
            characterAnimator.gameObject.SetActive(!characterAnimator.gameObject.activeSelf);
            yield return new WaitForSeconds(blinkDuration);
        }
        characterAnimator.gameObject.SetActive(true);
    }
} 

