






using UnityEngine;

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    private Quaternion rotFix;

    void Start()
    {
        gyroEnabled = EnableGyro();
    }

    bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            // Rotate the gyroscope data to match Unity's camera system.
            rotFix = new Quaternion(0, 0, 1, 0);  // Adjust the rotation quaternion to compensate for the device's default orientation

            return true;
        }
        return false;
    }

    void Update()
    {
        if (gyroEnabled)
        {
            // Apply the gyroscope's attitude to the camera's local rotation
            // Invert the X and Z axes to align the camera correctly
            transform.localRotation = Quaternion.Euler(90f, 0f, 0f) * gyro.attitude * rotFix;
        }
    }
}
