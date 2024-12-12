using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ReturnToMenu : MonoBehaviour
{
    void Update()
    {
        // Detecta el botón de menú en los controladores
        var leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        var rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (CheckMenuButtonPressed(leftHandDevice) || CheckMenuButtonPressed(rightHandDevice))
        {
            ReloadCurrentScene();
        }
    }

    bool CheckMenuButtonPressed(InputDevice device)
    {
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out bool isPressed))
        {
            return isPressed;
        }
        return false;
    }

    void ReloadCurrentScene()
    {
        // Obtén el nombre de la escena activa y recárgala
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
