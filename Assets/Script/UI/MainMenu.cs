using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpgradeWP()
    {
        int currentWp = WeaponManager.Instance.currentWp;
        int wpQuantity = WeaponManager.Instance.wpQuantity.Length;

        WeaponManager.Instance.currentWp = currentWp + 1;

        if (WeaponManager.Instance.currentWp > wpQuantity)
        {
            WeaponManager.Instance.currentWp = wpQuantity;
            Debug.Log("This is the strongest weapon");

        }

        Debug.Log("Weapon: " + currentWp);
    }
}
