using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButtonAction : MonoBehaviour
{
    public Button button;
    public Material skyboxMaterial; 

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(() => OnSceneSelect(skyboxMaterial));
        }
        else
        {
            Debug.LogError("Button reference is missing!");
        }
    }

    public void OnSceneSelect(Material selectedMaterial)
    {
        SkyboxMaterialHolder.skyboxMaterial = selectedMaterial;

        SceneManager.LoadScene("SampleScene");
    }
}
