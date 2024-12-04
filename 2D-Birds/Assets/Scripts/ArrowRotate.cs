using UnityEngine;

public class ArrowRotate : MonoBehaviour
{
    private Vector3 initialScale;

    [SerializeField] private float directionScaleMultiplier = 10f;
    [SerializeField] private float offsetAngle = 0f;

    [SerializeField] private float minAngle = -45f;
    [SerializeField] private float maxAngle = 45f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set scale
        float distance = Vector3.Distance(transform.position, mousePosition);
        transform.localScale = new Vector3(initialScale.x * distance / directionScaleMultiplier, initialScale.y, initialScale.z);

        // Rotate
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offsetAngle;

        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
