using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region REFERENCES

    public static UIManager Instance;

    public GameObject interactionIndicator;

    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        DisplayInteractionIndicator(false);
    }


    #region METHODS

    public void DisplayInteractionIndicator(bool enabled)
    {
        interactionIndicator.SetActive(enabled);
    }


    #endregion
}
