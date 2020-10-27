using System.Collections;
using UnityEngine;

public class Importer : MonoBehaviour
{
    public Browser browser;
    public AudioImporter importer;
    public AudioSource audioSource;

    void Awake()
    {
        browser.FileSelected += OnFileSelected;
    }

    private void OnFileSelected(string path)
    {
        Destroy(audioSource.clip);

        Debug.Log("Starting coroutine");

        StartCoroutine(Import(path));
    }

    IEnumerator Import(string path)
    {

        Debug.Log("path is " + path);

        importer.Import(path);

        while (!importer.isInitialized && !importer.isError)
            yield return null;

        if (importer.isError)
            Debug.LogError(importer.error);

        audioSource.clip = importer.audioClip;
        importer.Loaded();
        audioSource.Play();
    }
}
