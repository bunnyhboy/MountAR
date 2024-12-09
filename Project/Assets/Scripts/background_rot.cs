using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 2f; 

    void Update()
    {
      

    
    GetComponent<Skybox>().material.SetFloat("_Rotation", Time.time *rotationSpeed );
    }
}
