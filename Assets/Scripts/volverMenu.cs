using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class volverMenu : MonoBehaviour
{
    public void VolverMenu()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
