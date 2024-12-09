using UnityEngine;
using System.Collections;

public class SphereInversion:MonoBehaviour
{

    void Start(){

        Mesh mesh=this.GetComponent<MeshFilter>().mesh;

        Vector3[] normals = mesh.normals;

        for(int i=0;i<normals.Length;i++)
        {
            normals[i]=-normals[i];
        }

        mesh.normals=normals;

        for(int i=0;i<mesh.subMeshCount;i++)
        {
            int[] tris=mesh.GetTriangles(i);
            for(int j=0;j<tris.Length;j+=3)
            {
                (tris[j],tris[j+1])=(tris[j+1],tris[j]);
            }
            mesh.SetTriangles(tris,i);
        }


    }

    
}
