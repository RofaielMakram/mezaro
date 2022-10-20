using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
   public GameObject[] characters;
   public int selectedCharacter = 0;


    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    public void select1()
    {
        selectedCharacter = 0;
    }
    public void select2()
    {
        selectedCharacter = 1;
    }
    public void select3()
    {
        selectedCharacter = 2;
    }
}
