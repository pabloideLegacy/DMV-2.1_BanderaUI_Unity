using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public Image LoaderImage;
    public TextMeshProUGUI LoadingText;    
    [SerializeField]
    private float Carga = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoaderImage.fillAmount = Carga; // Initialize the loader image fill amount
        LoadingText.text = Mathf.FloorToInt(Carga * 100).ToString() + "%"; // Initialize the loading text
    }

    public void StartProgress()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator LoadScene()
    {
        while (Carga < 1)
        {
        Carga += 0.1f; // Increment the loading progress
        LoaderImage.fillAmount = Carga; // Update the loader image fill amount
        LoadingText.text = Mathf.FloorToInt(Carga * 100).ToString() + "%"; // Update the loading text
        yield return new WaitForSeconds(0.1f); // Simulate loading time 
        }
        if (Carga >= 1)
        {
            // Load the next scene or perform any necessary actions after loading is complete
            // For example: SceneManager.LoadScene("NextScene");
            SceneManager.LoadScene("Examen_PrimerParcial"); // Replace "NextScene" with the actual name of your next scene
        }
    }

}
