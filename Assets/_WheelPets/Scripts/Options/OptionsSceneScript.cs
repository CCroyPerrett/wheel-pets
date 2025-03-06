using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

// todo beautify reset data pop up
// todo beautify adopt a pet pop up
public class OptionsSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject adoptAPetPopUp;

    [SerializeField]
    private GameObject resetDataPopUp;

    [SerializeField]
    private PetScript petPrefabObject;

    [SerializeField]
    private Slider dominantColorSlider;

    [SerializeField]
    private Slider secondaryColorSlider;

    public void OnClickBackButon()
    {
        SceneChange.LoadTitle();
    }

    public void OnClickEnglishButton()
    {
        SetLocale("en");
    }

    public void OnClickSpanishButton()
    {
        SetLocale("es");
    }

    public void OnClickFrenchButton()
    {
        SetLocale("fr");
    }

    public void OnClickFactorResetButton()
    {
        resetDataPopUp.SetActive(true);
    }

    public void OnClickRandomNameButton()
    {
        // todo implement random new name
    }

    /// <summary>
    /// Handles the Puppy button click event. Sets the pet type to Dog.
    /// /// </summary>
    public void OnClickPuppyButton()
    {
        petData.animalType = PlayerData.AnimalType.Dog;
        petPrefabObject.UpdateLook();
        if (Debug.isDebugBuild)
        {
            Debug.Log("OptionsScene\tChange Animal to Dog");
        }
    }

    /// <summary>
    /// Handles the Kitten button click event. Sets the pet type to Cat.
    /// </summary>
    public void OnClickKittenButton()
    {
        petData.animalType = PlayerData.AnimalType.Cat;
        petPrefabObject.UpdateLook();

        if (Debug.isDebugBuild)
        {
            Debug.Log("OptionsScene\tChange Animal to Cat");
        }
    }

    /// <summary>
    /// Handles the Rabbit button click event. Sets the pet type to Rabbit.
    /// </summary>
    public void OnClickRabbitButton()
    {
        petData.animalType = PlayerData.AnimalType.Rabbit;
        petPrefabObject.UpdateLook();

        if (Debug.isDebugBuild)
        {
            Debug.Log("OptionsScene\tChange Animal to Rabbit");
        }
    }

    private PlayerData playerData;
    private PlayerData.PetData petData;

    private void Start()
    {
        playerData = Data.GetPlayerData();
        petData = playerData.petData;

        // 1st time game is launched, adoption process
        if (playerData.hasAdoptPet)
        {
            adoptAPetPopUp.SetActive(false);
        }
        else
        {
            playerData.hasAdoptPet = true;
            adoptAPetPopUp.SetActive(true);
        }

        // set up sliders values
        dominantColorSlider.value = petData.dominantColorHue;
        secondaryColorSlider.value = petData.secondaryColorHue;

        // set up sliders event listenr
        dominantColorSlider.onValueChanged.AddListener(
            (value) =>
            {
                petData.dominantColorHue = value;
                petPrefabObject.UpdateLook();
            }
        );
        secondaryColorSlider.onValueChanged.AddListener(
            (value) =>
            {
                petData.secondaryColorHue = value;
                petPrefabObject.UpdateLook();
            }
        );
    }

    private void SetLocale(string localeCode)
    {
        var selectedLocale =
            LocalizationSettings.AvailableLocales.Locales.Find(locale =>
                locale.Identifier.Code == localeCode
            );
        if (selectedLocale != null)
        {
            LocalizationSettings.SelectedLocale = selectedLocale;
            Debug.Log($"Locale set to {localeCode}");
        }
        else
        {
            Debug.LogWarning($"Locale {localeCode} not found");
        }
    }
}
