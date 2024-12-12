using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GoToMainScene : MonoBehaviour
{
    public string targetSceneName = "MAIN"; // Nombre de la escena a la que quieres redirigir

    void Update()
    {
        // Detecta el botón X en los controladores
        var leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        var rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (CheckXButtonPressed(leftHandDevice) || CheckXButtonPressed(rightHandDevice))
        {
            GoToMain();
        }
    }

    bool CheckXButtonPressed(InputDevice device)
    {
        // El botón X suele estar asociado a "primaryButton"
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            return isPressed;
        }
        return false;
    }

    void GoToMain()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
