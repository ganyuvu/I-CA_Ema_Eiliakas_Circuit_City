using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera objectCamera;//The camera to switch to when interacting with this object

    public Camera GetObjectCamera()
    {
        return objectCamera;
    }
}
