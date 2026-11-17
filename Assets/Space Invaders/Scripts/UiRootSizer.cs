using UnityEngine;
using UnityEngine.UIElements;

public class UiRootSizer : MonoBehaviour
{
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.StretchToParentSize();
    }
}
