using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOTTOM : MonoBehaviour
{
    SkinnedMeshRenderer m_mesh;
    void Start()
    {
        ChangeSkin();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

   public void ChangeSkin()
    {
        m_mesh = GetComponent<SkinnedMeshRenderer>();
        m_mesh.sharedMesh = Resources.Load<Mesh>(PlayerPrefs.GetString("Bottom", "Bottoms"));
        m_mesh.sharedMaterial = Resources.Load<Material>(PlayerPrefs.GetString("MAT", "Player"));
    }
}
