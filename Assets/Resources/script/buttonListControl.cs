using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonListControl : MonoBehaviour {


	public GameObject buttonTemplate;
	public startScreen loadScene;

	private List<GameObject> btn = new List<GameObject>();

	// Use this for initialization
	public void loadSavedData () 
	{

		if(btn.Count > 0 ){
			foreach(GameObject b in btn)
			{
				Destroy(b.gameObject);
			}
			btn.Clear ();
		}
		//Debug.Log (saveLoad.GameTersimpan.Count);

		foreach (PlayerData pd in saveLoad.GameTersimpan) {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            btn.Add(button);
            button.SetActive(true);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            button.name = pd.NamaPemain;
            button.transform.GetChild(0).GetComponent<Text>().text = pd.NamaPemain;
            button.GetComponent<Button>().onClick.AddListener(openScene);
		}
	}

	public void openScene(){
        foreach (PlayerData pd in saveLoad.GameTersimpan) {
            if(EventSystem.current.currentSelectedGameObject.name == pd.NamaPemain) {
                PlayerData.current = pd;
                loadScene.loadGameAsync();
            }
        }
	}


}
