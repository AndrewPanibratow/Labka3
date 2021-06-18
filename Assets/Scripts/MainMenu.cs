using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private const float cameraRotationSpeed = 3.0f;
    public GameObject levelButtonPrefab;
    public GameObject levelButtonContainer;
    public GameObject shopButtonPrefab;
    public GameObject shopButtonContainer;

    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;
    private void Start()
    {
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach(Sprite thumbnail in thumbnails)
        {
            cameraTransform = Camera.main.transform;
            GameObject container = Instantiate(levelButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent (levelButtonContainer.transform , false);

            string sceneName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));
        }

        Sprite[] skins = Resources.LoadAll<Sprite>("Player");
        foreach (Sprite skin in skins)
        {
            cameraTransform = Camera.main.transform;
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = skin;
            container.transform.SetParent(shopButtonContainer.transform, false);
        }
    }

    private void Update()
    {
        if (cameraDesiredLookAt != null)
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, cameraRotationSpeed * Time.deltaTime);
        }
    }
    private void LoadLevel(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void LookAtMenu(Transform menuTransform)
    {
        cameraDesiredLookAt = menuTransform;
    }
}
