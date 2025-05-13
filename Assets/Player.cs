using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health, MaxHealth, Concentration, MaxConcentration;
    [SerializeField]
    private HealthBarUI healthBar;
    [SerializeField]
    private ConcentrationBarUI concentrationBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
        concentrationBar.SetMaxConcentration(MaxConcentration);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetHealth(-10f);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            SetHealth(+10f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetConcentration(-10f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetConcentration(+10f);
        }
    }
    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        healthBar.SetHealth(Health);
    }
    public void SetConcentration(float concentrationChange)
    {
        Concentration += concentrationChange;
        Concentration = Mathf.Clamp(Concentration, 0, MaxConcentration);
        concentrationBar.SetConcentration(Concentration);
    }
}
    