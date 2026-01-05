using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float speed = 7f;
    public float jumpForce = 12f;
    
    [Header("Can Sistemi")]
    public int can = 3; 
    public Image[] kalpler; 
    
    [Header("Bağlantılar")]
    public GameObject soruPaneli; 

    private Rigidbody2D rb;
    private Animator anim; 
    private bool isFacingRight = true;
    private float moveInput;
    
    // Aynı anahtarın sürekli panel açmasını engelleyen hafıza değişkeni
    private GameObject sonDegilenAnahtar;

    public static string sonOynananSahne;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        if (kalpler != null) {
            foreach (Image kalp in kalpler) {
                if (kalp != null) kalp.gameObject.SetActive(true);
            }
        }
    }

    void Update() {
        // SORU PANELİ AÇIKKEN
        if (soruPaneli != null && soruPaneli.activeInHierarchy) {
            // HAREKETİ DURDUR: Karakterin o anki hızını tamamen sıfırla
            rb.velocity = Vector2.zero; 
            moveInput = 0; // Giriş verisini de sıfırla
            
            if(anim != null) anim.SetFloat("Speed", 0f);
            return; // Kodun geri kalanını okuma
        }

        // HAREKET GİRDİSİ
        moveInput = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) moveInput = 1;
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) moveInput = -1;

        // ZIPLAMA
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && Mathf.Abs(rb.velocity.y) < 0.1f) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (anim != null) {
            anim.SetFloat("Speed", Mathf.Abs(moveInput)); 
            anim.SetBool("isJumping", Mathf.Abs(rb.velocity.y) > 0.1f);
        }

        if (moveInput > 0 && !isFacingRight) Flip();
        else if (moveInput < 0 && isFacingRight) Flip();
    }

    void FixedUpdate() {
        // Eğer panel açık değilse normal hareket uygula
        if (!(soruPaneli != null && soruPaneli.activeInHierarchy)) {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("anahtar")) {
            // Eğer yeni bir anahtara değdiysek paneli aç
            if (other.gameObject != sonDegilenAnahtar) {
                if (soruPaneli != null) {
                    sonDegilenAnahtar = other.gameObject;
                    
                    // PANELİ AÇMADAN HEMEN ÖNCE HIZI SIFIRLA (Çok Önemli)
                    rb.velocity = Vector2.zero;
                    
                    soruPaneli.SetActive(true);
                    
                    QuestionManager qm = soruPaneli.GetComponent<QuestionManager>();
                    if (qm != null) qm.SoruSor(other.name, other.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // Anahtardan uzaklaşınca hafızayı sıfırla
        if (other.CompareTag("anahtar")) {
            sonDegilenAnahtar = null; 
        }
    }

    public void CanKaybet() {
        if (can > 0) {
            can--; // Önce canı azalt
            
            // Kalpler dizisindeki ilgili kalbi kapat
            // can değişkeni artık 2 ise, 2. indeksteki kalbi (yani 3. kalbi) kapatırız
            if(kalpler != null && can < kalpler.Length) {
                if(kalpler[can] != null) {
                    kalpler[can].gameObject.SetActive(false);
                    Debug.Log("Bir kalp silindi. Kalan can: " + can);
                }
            }
            
            if (can <= 0) {
                sonOynananSahne = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("KaybettinSahnesi"); 
            }
        }
    }

    void Flip() {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}