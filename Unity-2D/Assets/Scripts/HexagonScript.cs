using UnityEngine;

public class HexagonScript : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb2d.angularVelocity = 0;
            _rb2d.linearVelocity = Vector2.zero;
            _rb2d.AddForceY(200);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _rb2d.angularVelocity = 0;
            _rb2d.linearVelocity = Vector2.zero;
        }
        
        _rb2d.AddForceX(Input.GetAxis("Horizontal"));
        _rb2d.AddTorque(-Input.GetAxis("Vertical"));
    }
}