using System.Linq;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private Light[] _dayLights;
    private Light[] _nightLights;

    void Start()
    {
        _dayLights = GameObject
            .FindGameObjectsWithTag("DayLight")
            .Select(G => G.GetComponent<Light>())
            .ToArray();

        _nightLights = GameObject
            .FindGameObjectsWithTag("NightLight")
            .Select(G => G.GetComponent<Light>())
            .ToArray();

        SwitchLight();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            SwitchLight();
        }
    }

    private void SwitchLight()
    {
        GameState.isDay = !GameState.isDay;
        foreach (Light Light in _dayLights)
        {
            Light.enabled = GameState.isDay;
        }
        foreach (Light Light in _nightLights)
        {
            Light.enabled = !GameState.isDay;
        }
    }
}
