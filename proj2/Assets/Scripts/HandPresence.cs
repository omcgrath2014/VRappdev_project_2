using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    private GameObject spawnedController;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
      //  InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        //InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        // InputDevices.GetDevices(devices);
        //InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        foreach (var item in devices)
        {
            Debug.Log("Hello, world.");
            Debug.Log("Here" + item.name + item.characteristics + item.manufacturer);
        }
        Debug.Log(devices.Count);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if(prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool primary2DAxisClick);
        //if (primary2DAxisClick)
          //  Debug.Log("Got Primary 2D Avis Click");

       // targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
       // if (triggerValue > 0.1f)
        //   Debug.Log("Pressing trigger" + triggerValue);

      // targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
       // if (primary2DAxisValue != Vector2.zero)
          //  Debug.Log("Pressing Primary Button" + primary2DAxisValue);

  
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool primary2DAxisClick) && primary2DAxisClick)
            Debug.Log("Got Primary 2D Avis Click");

        
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            Debug.Log("Pressing trigger" + triggerValue);

      
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
            Debug.Log("Pressing Primary Button" + primary2DAxisValue);


    }
}
