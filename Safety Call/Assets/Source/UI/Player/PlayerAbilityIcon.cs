using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAbilityIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject abilityPanel;  
    [SerializeField] private TextMeshProUGUI abilityText; 
    [SerializeField] private int abilityIndex;           
    
    [SerializeField] private PlayerUiDrawer viewModel;  
    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (abilityPanel == null || abilityText == null)
        {
            return;
        }
        abilityPanel.SetActive(true);
        viewModel.ShowAbilityPanel(abilityIndex, abilityPanel, abilityText);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (abilityPanel != null)
        {
            abilityPanel.SetActive(false);
        }
    }
}
