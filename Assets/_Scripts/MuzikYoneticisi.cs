using UnityEngine;

public class MuzikYoneticisi : MonoBehaviour
{
    private static MuzikYoneticisi instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Müzik ölümsüz yapıldı, sahne değişse de çalacak!");
        }
    }
}