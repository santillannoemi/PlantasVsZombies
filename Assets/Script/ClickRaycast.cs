using UnityEngine;
using UnityEngine.Events;
 
public class ClickRaycast : MonoBehaviour
{
    private float raycatsDistance = 1000f;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private string sunTag;
    [SerializeField]
    private UnityEvent<int> onSunClicked;
    private bool IsActive = true;
    public void SetActive(bool active)
    {
        IsActive = active;
    }
    private void Update()
    {
        if (!IsActive) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, raycatsDistance, layerMask))
            {
                if (hit.collider.CompareTag(sunTag))
                {
                    SunCollected(hit.collider.gameObject);
                }
            }
        }
    }
    private void SunCollected(GameObject gameObject)
    {
        if(gameObject.TryGetComponent<Sun>(out Sun sun))
        {
            sun.Collect();
            onSunClicked.Invoke(sun.Value);
        }
    }
}
 
