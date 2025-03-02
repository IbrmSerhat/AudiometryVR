using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class NewInteractionTest : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable;

    private void Start()
    {
        if (simpleInteractable == null)
        {
            Debug.LogError("XRSimpleInteractable component not found on this GameObject.");
            return;
        }
        simpleInteractable.activated.AddListener(OnActivated);
    }

    private void OnActivated(ActivateEventArgs args)
    {
        print("Basarili");
    }

    private void OnDestroy()
    {
        if (simpleInteractable != null)
        {
            simpleInteractable.activated.RemoveListener(OnActivated);
        }
    }
}