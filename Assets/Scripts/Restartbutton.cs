using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Restartbutton : MonoBehaviour, IPointerClickHandler
{
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("CLICKED");
            SceneManager.LoadScene("MainGame");
        }
    }

}
