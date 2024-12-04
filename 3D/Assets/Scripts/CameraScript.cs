using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private Transform _character;
    private InputAction _lookAction;
    private Vector3 _cameraAngles, _cameraAngles0;
    private Vector3 _r;
    private const float SensitivityH = 5.0f;
    private const float SensitivityV = -3.0f;
    private const float MinFpvDistance = 0.9f;
    private const float MaxFpvDistance = 9.0f;
    private bool _isPos3;

    void Start()
    {
        _lookAction = InputSystem.actions.FindAction("Look");
        _cameraAngles0 = _cameraAngles = this.transform.eulerAngles;
        _character = GameObject.Find("Character").transform;
        _r = this.transform.position - _character.position;
        _isPos3 = false;
    }

    void Update()
    {
        Vector2 Wheel = Input.mouseScrollDelta;
        if(Wheel.y != 0)
        {
            if (_r.magnitude >= MaxFpvDistance)
            {
                _isPos3 = true;

                if (Wheel.y > 0)
                {
                    _r *= 1 - Wheel.y / 10;
                }
                
                GameState.isFpv = false;
            }
            else
            {
                _isPos3 = false;

                if(_r.magnitude >= MinFpvDistance)
                {
                    float Rr = _r.magnitude * (1 - Wheel.y / 10);
                    if (Rr <= MinFpvDistance)
                    {
                        _r *= 0.01f;
                    }
                    else
                    {
                        _r *= (1 - Wheel.y / 10);
                    }
                    
                    GameState.isFpv = false;
                }
                else
                {
                    if(Wheel.y < 0)
                    {
                        _r *= 100f;
                        GameState.isFpv = true;
                    }
                }
            }
        }

        Vector2 LookValue = _lookAction.ReadValue<Vector2>();
        if(LookValue != Vector2.zero)
        {
            _cameraAngles.x += LookValue.y * Time.deltaTime * SensitivityV;
            _cameraAngles.y += LookValue.x * Time.deltaTime * SensitivityH;
            this.transform.eulerAngles = _cameraAngles;
        }
        this.transform.position = _character.position + 
            Quaternion.Euler(_cameraAngles.x - _cameraAngles0.x, _cameraAngles.y - _cameraAngles0.y, 0) * _r;
    }
}