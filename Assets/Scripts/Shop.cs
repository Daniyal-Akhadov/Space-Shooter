using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    [SerializeField] private static int _credits = 50;

    [Header("TextsUI")]
    [SerializeField] private Text _damageValueText;
    [SerializeField] private Text _healthValueText;
    [SerializeField] private Text _creditsText;
    [SerializeField] private Text _damageCreditsPriceText;
    [SerializeField] private Text _healthCreditsPriceText;

    [Header("Prices")]
    [SerializeField] private int _damageCreditsPrice = 50;
    [SerializeField] private int _healthCreditsPrice = 100;

    [Header("AddingValues")]
    [SerializeField] private int _addingHealth;
    [SerializeField] private int _addingDamage;

    [Header("PlayerFields")]
    [SerializeField] private PlayerBullet _playerBullet;
    [SerializeField] private PlayerHealth _playerHealth;

    private static string CREDITS_KEY = "Credits";
    private static string DAMAGE_KEY = "Damage";
    private static string HEALTH_KEY = "Health";


    private void Awake()
    {
        if (PlayerPrefs.HasKey(CREDITS_KEY))
        {
            _credits = PlayerPrefs.GetInt(CREDITS_KEY, _credits);
            Debug.Log($"Загрузка данных вышла. _credits = {_credits}");
        }

        if (PlayerPrefs.HasKey(DAMAGE_KEY))
        {
            _playerBullet.Damage = PlayerPrefs.GetInt(DAMAGE_KEY, _playerBullet.Damage);
        }

        if (PlayerPrefs.HasKey(HEALTH_KEY))
        {
            _playerHealth.Value = PlayerPrefs.GetInt(HEALTH_KEY, _playerHealth.Value);
        }

        UpdateTextDamageValue();
        UpdateTextHealthValue();
        UpdateTextCreditsValue();

        _healthCreditsPriceText.text = $"HP UP - {_healthCreditsPrice} CREDITS";
        _damageCreditsPriceText.text = $"DMG UP - {_damageCreditsPrice} CREDITS";

    }

    public static void AddCredits(int value)
    {
        _credits += value;
        PlayerPrefs.SetInt(CREDITS_KEY, _credits);
        Debug.Log("Credits = " + _credits);
        Debug.Log("Health = " + _credits);

    }
    public void ImproveHealth()
    {
        if (_credits >= _healthCreditsPrice)
        {
            _credits -= _healthCreditsPrice;
            _playerHealth.AddHealth(_addingHealth);
            PlayerPrefs.SetInt(HEALTH_KEY, _playerHealth.Value);
            PlayerPrefs.Save();
            UpdateTextHealthValue();
            UpdateTextCreditsValue();
        }
    }

    public void ImproveDamage()
    {
        if (_credits >= _damageCreditsPrice)
        {
            _credits -= _damageCreditsPrice;
            _playerBullet.AddDamage(_addingDamage);
            PlayerPrefs.SetInt(DAMAGE_KEY, _playerBullet.Damage);
            PlayerPrefs.Save();
            UpdateTextDamageValue();
            UpdateTextCreditsValue();
        }
    }

    private void UpdateTextDamageValue()
    {
        _damageValueText.text = $"{_playerBullet.Damage}";
    }

    private void UpdateTextHealthValue()
    {
        _healthValueText.text = $"{_playerHealth.Value}";
    }

    private void UpdateTextCreditsValue()
    {
        _creditsText.text = $"{_credits}";
    }



}
