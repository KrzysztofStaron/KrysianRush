using UnityEngine;

public class menuManager : MonoBehaviour
{
    [SerializeField]private GameObject menu;

    public void Show(){
      menu.SetActive(true);
    }

    public void Hide(){
      menu.SetActive(false);//change
    }
}
