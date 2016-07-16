using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject[] AIButtons;
    public GameObject AIDrawer, CharDrawer;
    private GameObject activeAIButton;
    private Color selectedColor = new Color(1, 0.388f, 0.388f);
    private bool AIretracted =  false, CharRetracted = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setActiveAI(int index)
    {
        activeAIButton = AIButtons[index];

        foreach(GameObject AIButton in AIButtons)
        {
            AIButton.GetComponent<Image>().color = Color.white;
        }
        AIButtons[index].GetComponent<Image>().color = selectedColor;
    }

    public void showAIList()
    {
        AIretracted = !AIretracted;
       AIDrawer.GetComponent<Animator>().SetBool("desplegar", AIretracted);

    }

    public void showCharList()
    {
        CharRetracted = !CharRetracted;
        CharDrawer.GetComponent<Animator>().SetBool("desplegar", CharRetracted);

    }
}
