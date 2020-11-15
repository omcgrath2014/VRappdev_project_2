using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        // InputDevices.GetDevices(devices);
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        foreach (var item in devices)
        {
            Debug.Log("Hello, world.");
            Debug.Log("Here" + item.name + item.characteristics + item.manufacturer);
        }
        Debug.Log(devices.Count);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool primaryButtonValue);
        //targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float primaryButtonValue);
        //Debug.Log("Got Here.");
        //Debug.Log("Next the value" + primaryButtonValue);
        //if (primaryButtonValue > 0.1f)
            if (primaryButtonValue)
                 Debug.Log("Pressing Primary Button");
               // Debug.Log("Pressing Trigger");
    }
}
