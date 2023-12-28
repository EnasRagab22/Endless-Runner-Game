
using UnityEngine;

public class BODY : MonoBehaviour
{
    SkinnedMeshRenderer m_mesh;
    void Start()
    {
        ChangeSkin();
    }



    public void ChangeSkin()
    {
        m_mesh = GetComponent<SkinnedMeshRenderer>();
        m_mesh.sharedMesh = Resources.Load<Mesh>(PlayerPrefs.GetString("Body", "Body"));
        m_mesh.sharedMaterial = Resources.Load<Material>(PlayerPrefs.GetString("MAT", "Player"));
    }
}
