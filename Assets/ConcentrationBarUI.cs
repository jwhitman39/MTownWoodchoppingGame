using UnityEngine;

public class ConcentrationBarUI : MonoBehaviour
{
    public float Concentration, MaxConcentration, Width, Height;
    [SerializeField]
    private RectTransform concentrationBar;

    public void SetMaxConcentration(float maxConcentration)
    {
        MaxConcentration = maxConcentration;
    }
    public void SetConcentration(float concentration)
    {
        Concentration = concentration;
        float newWidth = (Concentration / MaxConcentration) * Width;
        concentrationBar.sizeDelta = new Vector2(newWidth, Height);
    }

}
