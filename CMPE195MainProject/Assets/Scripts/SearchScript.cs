using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchScript : MonoBehaviour
{
    public GameObject ContentHolder;
    public GameObject SearchBar;
    public void Update()
    {

    }

    public void Search()
    {
        //text input in search box
        string SearchText = SearchBar.GetComponent<TMP_InputField>().text;
        int searchTxtLength = SearchText.Length;
        foreach(Transform roomNumber in ContentHolder.transform){
            GameObject room = roomNumber.gameObject;
            //checking if room name is longer than input text
            if(room.GetComponentInChildren<TextMeshProUGUI>().text.Length >= searchTxtLength){
                if(room.GetComponentInChildren<TextMeshProUGUI>().text.ToLower().Contains(SearchText.ToLower())){
                    room.SetActive(true);
                }
                else{
                    room.SetActive(false);
                }
            }
        }

    }
}
