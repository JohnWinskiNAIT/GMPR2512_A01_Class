using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SwitchToScene02 : MonoBehaviour
{
    Button _changeToScene02Button;
    
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _changeToScene02Button = root.Q<Button>("ChangeToScene02");

        if (_changeToScene02Button != null )
        {
            _changeToScene02Button.clicked += OpenScene02;
        }
    }

    private void OnDisable()
    {
        if (_changeToScene02Button != null )
        {
            _changeToScene02Button.clicked -= OpenScene02;
        }
    }

    void OpenScene02()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene("Level01");
    }
}
