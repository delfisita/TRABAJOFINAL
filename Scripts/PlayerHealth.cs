using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para usar SceneManager
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Text gameOverText; // Referencia al componente de texto para mostrar el mensaje de Game Over

    private bool isGameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        gameOverText.gameObject.SetActive(false); // Oculta el mensaje de Game Over al principio
    }

    void Update()
    {
        if (currentHealth <= 0 && !isGameOver)
        {
            isGameOver = true;
            GameOver();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10); // Puedes ajustar la cantidad de daño que recibe el jugador aquí
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player health: " + currentHealth);
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // Muestra el mensaje de Game Over en pantalla
        Debug.Log("Game Over");

        // Cargar la escena de Game Over después de un breve retraso
        Invoke("LoadGameOverScene", 2f);
    }

    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene"); // Reemplaza "GameOverScene" con el nombre de tu escena de Game Over
    }
}
