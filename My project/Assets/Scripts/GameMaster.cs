using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int scene;

    private void GoToScene()
    {
        SceneManager.LoadScene(scene);
    }

}
