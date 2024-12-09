// using UnityEngine;
// using ZXing;
// using TMPro;
// using UnityEngine.UI;

// public class QRreader : MonoBehaviour
// {
//     [SerializeField]
//     private RawImage _rawImageBackground;

//     [SerializeField]
//     private AspectRatioFitter _asoectRatioFitter;

//     [SerializeField]
//     private TextMeshProUGUI _textOut;

//     [SerializeField]
//     private RectTransform _scanzone;

//     private bool _isCamAvailable;
//     private WebCamTexture _cameratexture;

//     public Texture back;

//     void Start()
//     {
//          if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
//     {
//         if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
//         {
//             Application.RequestUserAuthorization(UserAuthorization.WebCam);
//         }
//     }
//         SetUpCamera();
//     }
//     void Update()
//     {
//         UpdateCameraRender();
//     }

//     // private void SetUpCamera()
//     // {

//     //     WebCamDevice[] devices = WebCamTexture.devices;
//     //     if (devices.Length == 0)
//     //     {

//     //         _isCamAvailable = false;
//     //         return;
//     //     }
//     //     for (int i = 0; i < devices.Length; i++)
//     //     {
//     //         if (devices[i].isFrontFacing == false)
//     //         {
//     //          _cameratexture = new WebCamTexture(devices[i].name, (int)_scanzone.rect.width, (int)_scanzone.rect.height);
//     //         }
//     //     }
//     //     _cameratexture.Play();
//     //     _rawImageBackground.texture=_cameratexture;

//     //     _rawImageBackground.GetComponent<Renderer>().material.mainTexture = _cameratexture;
//     //     _isCamAvailable = true;

//     // }

//     private void SetUpCamera()
//     {
//         WebCamDevice[] devices = WebCamTexture.devices;
//         if (devices.Length == 0)
//         {
//             Debug.LogError("No camera devices found.");
//             _isCamAvailable = false;
//             return;
//         }

//         for (int i = 0; i < devices.Length; i++)
//         {
//             if (!devices[i].isFrontFacing)
//             {
//                 _cameratexture = new WebCamTexture(devices[i].name, (int)_scanzone.rect.width, (int)_scanzone.rect.height);
//                 break;
//             }
//         }

//         if (_cameratexture == null)
//         {
//             Debug.LogError("No rear-facing camera found.");
//             _isCamAvailable = false;
//             return;
//         }

//         _cameratexture.Play();

//         if (!_cameratexture.isPlaying)
//         {
//             Debug.LogError("WebCamTexture failed to start.");
//             _isCamAvailable = false;
//             return;
//         }

//         _rawImageBackground.texture = _cameratexture;
//         _isCamAvailable = true;
//     }




//     private void UpdateCameraRender()
//     {

//         if (_isCamAvailable == false)
//         {

//             return;

//         }
//         float ratio = (float)_cameratexture.width / (float)_cameratexture.height;
//         _asoectRatioFitter.aspectRatio = ratio;

//         int orientation = -_cameratexture.videoRotationAngle;
//         _rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
//     }

//     public void onClickScan()
//     {
//         Scan();

//     }
//    private void Scan()
// {
//     if (!_isCamAvailable)
//     {
//         _textOut.text = "Camera not available.";
//         Debug.LogError("Camera is not available.");
//         return;
//     }

//     try
//     {
//         IBarcodeReader barcodeReader = new BarcodeReader();
//         Result result = barcodeReader.Decode(_cameratexture.GetPixels32(), _cameratexture.width, _cameratexture.height);

//         if (result != null)
//         {
//             Debug.Log($"QR Code Text: {result.Text}");
//             _textOut.text = result.Text;
//         }
//         else
//         {
//             Debug.LogWarning("QR Code could not be read.");
//             _textOut.text = "Failed to read QR Code.";
//         }
//     }
//     catch (System.Exception ex)
//     {
//         Debug.LogError($"Error during scan: {ex.Message}");
//         _textOut.text = "Failed in try block.";
//     }
// }
// }






using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QRreader : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackground;

    [SerializeField]
    private AspectRatioFitter _asoectRatioFitter;

    [SerializeField]
    private TextMeshProUGUI _textOut;

    [SerializeField]
    private RectTransform _scanzone;

    private bool _isCamAvailable;
    private WebCamTexture _cameratexture;

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                Application.RequestUserAuthorization(UserAuthorization.WebCam);
            }
        }
        SetUpCamera();
    }

    void Update()
    {
        UpdateCameraRender();
    }

    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.LogError("No camera devices found.");
            _isCamAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                _cameratexture = new WebCamTexture(devices[i].name, (int)_scanzone.rect.width, (int)_scanzone.rect.height);
                break;
            }
        }

        if (_cameratexture == null)
        {
            Debug.LogError("No rear-facing camera found.");
            _isCamAvailable = false;
            return;
        }

        _cameratexture.Play();

        if (!_cameratexture.isPlaying)
        {
            Debug.LogError("WebCamTexture failed to start.");
            _isCamAvailable = false;
            return;
        }

        _rawImageBackground.texture = _cameratexture;
        _isCamAvailable = true;
    }

    private void UpdateCameraRender()
    {
        if (_isCamAvailable == false) return;

        float ratio = (float)_cameratexture.width / (float)_cameratexture.height;
        _asoectRatioFitter.aspectRatio = ratio;

        int orientation = -_cameratexture.videoRotationAngle;
        _rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }

    public void onClickScan()
    {
        Scan();
    }

    private void Scan()
    {
        if (!_isCamAvailable)
        {
            _textOut.text = "Camera not available.";
            Debug.LogError("Camera is not available.");
            return;
        }

        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(_cameratexture.GetPixels32(), _cameratexture.width, _cameratexture.height);

            if (result != null)
            {
                Debug.Log($"QR Code Text: {result.Text}");
                _textOut.text = result.Text;

                // Compare QR result with dynamically loaded materials
                AssignSkyboxMaterial(result.Text);
            }
            else
            {
                Debug.LogWarning("QR Code could not be read.");
                _textOut.text = "Failed to read QR Code.";
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error during scan: {ex.Message}");
            _textOut.text = "Failed in try block.";
        }
    }

    private void AssignSkyboxMaterial(string qrResult)
    {
        Material[] materials = Resources.LoadAll<Material>("Materials"); // Load all materials in the Resources/Materials folder

        foreach (Material material in materials)
        {
            if (material.name.Equals(qrResult, System.StringComparison.OrdinalIgnoreCase))
            {
                SkyboxMaterialHolder.skyboxMaterial = material; // Store the material for other scenes
                Debug.Log($"Material found: {material.name}");
                SwitchToNextScene();
                return;
            }
        }

        Debug.LogWarning($"No matching material found for: {qrResult}");
        _textOut.text = "No matching material found.";
    }

    private void SwitchToNextScene()
    {
        // Switch to the next scene
        SceneManager.LoadScene("SampleScene"); // Replace "NextScene" with your scene name
    }
}
