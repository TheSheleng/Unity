using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool IsCanBeForce = true;

    [SerializeField] private Transform arrow;
    [SerializeField] private float respawnTime = 5f;
    [SerializeField] private float speedMultiplier = 100f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsCanBeForce)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float distance = Vector3.Distance(transform.position, mousePosition);
            Debug.Log(distance);
            rb2d.AddForce(distance * speedMultiplier * arrow.right);

            IsCanBeForce = false;
            StartCoroutine(ReturnToInitialPosition());
        }
    }

    private IEnumerator ReturnToInitialPosition()
    {
        yield return new WaitForSeconds(respawnTime);

        transform.position = initialPosition;
        transform.rotation = initialRotation;

        rb2d.linearVelocity = Vector2.zero;
        rb2d.angularVelocity = 0f;

        IsCanBeForce = true;
    }
}
