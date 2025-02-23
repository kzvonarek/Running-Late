using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] Toggle itemToggle;

    void OnMouseDown()
    {
        // activate checkmark on checklist
        itemToggle.isOn = true;

        // destroy object, player sprite updates accordingly
        Destroy(this.gameObject);
    }
}
