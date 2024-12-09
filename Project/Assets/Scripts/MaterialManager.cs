using UnityEngine;

public class SkyboxApplier : MonoBehaviour
{
    void Start()
    {
        // Get the material from the static holder
        Material skyboxMaterial = SkyboxMaterialHolder.skyboxMaterial;

        if (skyboxMaterial != null)
        {
            // Apply the material globally
            RenderSettings.skybox = skyboxMaterial;

            // Update the Skybox component on the main camera
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                Skybox skybox = mainCamera.GetComponent<Skybox>();
                if (skybox == null)
                {
                    // Add a Skybox component if it's missing
                    skybox = mainCamera.gameObject.AddComponent<Skybox>();
                }

                // Assign the material to the Skybox component
                skybox.material = skyboxMaterial;
            }

            // Optional: Refresh lighting settings
            DynamicGI.UpdateEnvironment();
        }
        else
        {
            Debug.LogWarning("No skybox material passed to the scene.");
        }
    }
}
