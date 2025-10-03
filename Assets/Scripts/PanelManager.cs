using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;

    //private GameObject startPanel;
    //private GameObject nextPanel;
    //private GameObject overPanel;
    [Header("Panels")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private GameObject overPanel;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //startPanel = UIController.Instance.startPanel;
        //nextPanel = UIController.Instance.nextPanel;
        //overPanel = UIController.Instance.overPanel; 
        //Instantiate(startPanel);
        //Instantiate(nextPanel);
        //Instantiate(overPanel);
        ShowStartPanel();
    }

    public void DisableAllPanels()
    {
        UIController.Instance.currentState = GameState.Running;
        startPanel.SetActive(false);
        nextPanel.SetActive(false);
        overPanel.SetActive(false);
        Debug.Log("All Panels Disabled");
    }

    public void ShowStartPanel()
    {
        startPanel.SetActive(true);
        nextPanel.SetActive(false);
        overPanel.SetActive(false);
    }

    public void ShowNextPanel()
    {
        startPanel.SetActive(false);
        nextPanel.SetActive(true);
        overPanel.SetActive(false);
    }

    public void ShowOverPanel()
    {
        startPanel.SetActive(false);
        nextPanel.SetActive(false);
        overPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
