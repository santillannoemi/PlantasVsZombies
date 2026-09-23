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
        characterAnimator.Play("Die", 0, 0f);
        yield return characterAnimator.WaitForCurrentAnimation();
        gameObject.SetActive(false);
    }
}
