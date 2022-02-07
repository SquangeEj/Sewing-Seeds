using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class LightingManager : MonoBehaviour
{   // references
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;

    private void Start()
    {
        TimeOfDay = 8;
    }
    private void Update()
    {
        if (Preset == null)
            return;

        if(Application.isPlaying)
        {
            TimeOfDay += 0.001f;
            TimeOfDay %= 24;
            UpdateLighting(TimeOfDay / 24f);
        }
    }
    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColour.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColour.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColour.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return; 
                }
        }
        }
    }
}
