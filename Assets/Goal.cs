using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
  
   
		private void OnTriggerEnter(Collider other)
		{
			var currentScene = SceneManager.GetActiveScene();
			int currentLevel = int.Parse(currentScene.name.Split("Level ")[1]);
			int nextLevel = currentLevel + 1;

			var nextSceneBuildIndex = SceneUtility.GetBuildIndexByScenePath("Level " + nextLevel);
			if (nextSceneBuildIndex == -1)
			{
				SceneManager.LoadScene(0);
			}
			else
			{
				SceneManager.LoadScene(nextLevel);
			}
		}


	
}