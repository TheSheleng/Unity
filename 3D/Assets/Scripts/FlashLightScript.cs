using System;
using UnityEngine;

public class FlashLightScript : MonoBehaviour
{
    private Transform _parentTransform;
    private Transform _flashLightTransform;
    private Light _light;
    float _charge;
    private float _workTime = 5;
    
    void Start()
    {
        _parentTransform = transform.parent;

        if (_parentTransform == null)
        {
            Debug.LogError("FlashLightScript: Parent transform not found");
        }

        _light = GetComponent<Light>();
        _charge = 1;
    }

    private void Update()
    {
        if (!_parentTransform)
        {
            return;
        }

        if (_charge > 0 && !GameState.isDay)
        {
            _light.intensity = _charge;
            _charge -= Time.deltaTime / _workTime;
        }

        if (GameState.isFpv)
        {
            _flashLightTransform.forward = Camera.main.transform.forward;
        }
        else
        {
            Vector3 F = Camera.main.transform.forward;
            F.y = 0;

            if (F == Vector3.zero)
            {
                F = Camera.main.transform.up;
            }

            _flashLightTransform.forward = F;
        }
    }
}