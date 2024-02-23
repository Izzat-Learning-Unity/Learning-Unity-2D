using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCont : MonoBehaviour
{
    public void PlayGame()
    {
        int selectedCharacter = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.Instance.CharIndex = selectedCharacter;
        

        SceneManager.LoadScene("Gameplay");

    }
}
