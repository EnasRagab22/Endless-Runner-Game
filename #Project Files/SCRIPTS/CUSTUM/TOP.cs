using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOP : MonoBehaviour
{
    SkinnedMeshRenderer m_mesh;

    private void Start()
    {
        ChangeSkin();
    }
    public void ChangeSkin()
    {
        m_mesh = GetComponent<SkinnedMeshRenderer>();
        m_mesh.sharedMesh = Resources.Load<Mesh>(PlayerPrefs.GetString("Top", "Tops"));
        m_mesh.sharedMaterial = Resources.Load<Material>(PlayerPrefs.GetString("MAT", "Player"));
    }
}
