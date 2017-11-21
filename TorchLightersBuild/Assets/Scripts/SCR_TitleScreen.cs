using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_TitleScreen : MonoBehaviour {

	public void loadScene(int sceneID) {
		SceneManager.LoadScene (sceneID);
	}
}
