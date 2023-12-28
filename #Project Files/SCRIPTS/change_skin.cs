using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_skin : MonoBehaviour
{

    SkinnedMeshRenderer m_mesh;
    void Start()
    {
        m_mesh = GetComponent<SkinnedMeshRenderer>();
        m_mesh.sharedMesh = Resources.Load<Mesh>("CL_1_TOP");
        m_mesh.sharedMaterial = Resources.Load<Material>("CLOTH_1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
