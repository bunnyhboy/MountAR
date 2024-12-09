using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject scrollbar; 

    // public void ChangeScene()
    // {
    //     SceneManager.LoadScene("SampleScene");  
    // }

    // Function to close the application


    public void CloseApplication()
    {
        Application.Quit();  
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    public void HideButtons(){

        foreach(GameObject button in buttons)
        {
            button.SetActive(false);
        }
        scrollbar.SetActive(true);
    }
    public void QRScan(){

        SceneManager.LoadScene("QR");  
    }

}
