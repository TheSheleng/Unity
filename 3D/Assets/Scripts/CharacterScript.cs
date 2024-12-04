using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterScript : MonoBehaviour
{
    private Rigidbody _rb;
    private InputAction _moveAction;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 MoveValue = _moveAction.ReadValue<Vector2>();
        _rb.AddForce(250 * Time.deltaTime * // new Vector3(moveValue.x, 0, moveValue.y));
            (
                Camera.main.transform.right * MoveValue.x +
                Camera.main.transform.forward * MoveValue.y
            ));
    }
}
