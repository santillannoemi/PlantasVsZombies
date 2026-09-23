using UnityEngine;
 
public class DetectTarget : MonoBehaviour
{
    [SerializeField]
    private string targetTag;
    private float range;
    [SerializeField]
    private float rayHeightOffset = 0.5f;
    private bool IsActive;
    private System.Action<Transform> onTargetDetected;
    public void SetRange(float newRange)
    {
        range = newRange;
    }
    public void SetActive(bool newActive)
    {
        IsActive = newActive;
    }
    private void Update()
    {
        if (!IsActive) return;
        if(Physics.Raycast(transform.position + Vector3.up * rayHeightOffset, transform.forward, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                onTargetDetected?.Invoke(hit.transform);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * rayHeightOffset, transform.forward * range);
    }
}