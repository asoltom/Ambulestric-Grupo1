using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRInputDebugger : MonoBehaviour
{
    void Start()
    {
        // Lista los dispositivos al inicio
        ListDevices();
    }

    void Update()
    {
        // Presiona la tecla D para actualizar y listar los dispositivos conectados
        if (Input.GetKeyDown(KeyCode.D))
        {
            ListDevices();
        }
    }

    void ListDevices()
    {
        var devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        foreach (var device in devices)
        {
            Debug.Log($"Device found: {device.name}, Role: {device.characteristics}");
            ListDeviceFeatures(device);
        }
    }

    void ListDeviceFeatures(InputDevice device)
    {
        var featureUsages = new List<InputFeatureUsage>();
        if (device.TryGetFeatureUsages(featureUsages))
        {
            foreach (var feature in featureUsages)
            {
                Debug.Log($"Feature: {feature.name}, Type: {feature.type}");
            }
        }
        else
        {
            Debug.Log("No features found for this device.");
        }
    }
}
