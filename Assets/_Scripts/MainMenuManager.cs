using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject nasilOynanirPaneli;
    public GameObject ayarlarPaneli;

    [Header("Ses Ayarları")]
    public Slider sesSlider;

    void Start()
    {
        // 1. Daha önce kaydedilmiş ses seviyesini yükle, yoksa %100 (1f) aç
        float kaydedilenSes = PlayerPrefs.GetFloat("OyunSesSeviyesi", 1f);
        AudioListener.volume = kaydedilenSes;

        // 2. Slider varsa, değerini kaydedilen sese ayarla
        if (sesSlider != null)
        {
            sesSlider.value = kaydedilenSes;
            // Slider her hareket ettiğinde SetVolume fonksiyonunu çalıştır
            sesSlider.onValueChanged.AddListener(SetVolume);
        }

        // 3. Oyun başında panellerin kapalı olduğundan emin ol
        if (nasilOynanirPaneli != null) nasilOynanirPaneli.SetActive(false);
        if (ayarlarPaneli != null) ayarlarPaneli.SetActive(false);
    }

    // --- BUTON FONKSİYONLARI ---

    public void OyunuBaslat()
    {
        // "SampleScene" yerine kendi sahne adını (Bölüm 1) yazabilirsin
        SceneManager.LoadScene("SampleScene");
    }

    public void NasilOynanirAc()
    {
        nasilOynanirPaneli.SetActive(true);
    }

    public void AyarlarAc()
    {
        ayarlarPaneli.SetActive(true);
    }

    public void PaneliKapat(GameObject panel)
    {
        panel.SetActive(false);
    }

    // --- SES KONTROLÜ ---

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Tüm oyunun sesini değiştir
        PlayerPrefs.SetFloat("OyunSesSeviyesi", volume); // Sesi hafızaya kaydet
    }

    public void OyundanCik()
    {
        Debug.Log("Oyundan çıkılıyor...");
        Application.Quit(); // Sadece gerçek oyunda çalışır, Unity editörde çalışmaz
    }
}