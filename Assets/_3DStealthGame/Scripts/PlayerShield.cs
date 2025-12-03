using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shieldVisualPrefab; // Assign a sphere with glowing material

    private bool m_HasShield = false;
    private GameObject m_ShieldVisual;

    public bool HasShield
    {
        get { return m_HasShield; }
    }

    public void ActivateShield()
    {
        Debug.Log("PlayerShield: ActivateShield() called!");
        m_HasShield = true;
        Debug.Log("PlayerShield: m_HasShield set to TRUE");

        // Create the visual indicator if we have a prefab assigned
        if (shieldVisualPrefab != null && m_ShieldVisual == null)
        {
            Debug.Log("PlayerShield: Creating shield visual...");
            m_ShieldVisual = Instantiate(shieldVisualPrefab, transform.position, Quaternion.identity);
            m_ShieldVisual.transform.SetParent(transform);
            m_ShieldVisual.transform.localPosition = Vector3.zero;
            Debug.Log("PlayerShield: Shield visual created!");
        }
        else if (shieldVisualPrefab == null)
        {
            Debug.LogWarning("PlayerShield: Shield Visual Prefab is NULL! Assign it in the Inspector!");
        }
    }

    public void DeactivateShield()
    {
        Debug.Log("PlayerShield: DeactivateShield() called!");
        m_HasShield = false;

        // Remove the visual indicator
        if (m_ShieldVisual != null)
        {
            Destroy(m_ShieldVisual);
            m_ShieldVisual = null;
            Debug.Log("PlayerShield: Shield visual destroyed");
        }
    }
}