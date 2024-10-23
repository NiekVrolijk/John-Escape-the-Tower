using UnityEngine;
using TMPro; // Include the TextMeshPro namespace
using System.Text;

public class ColoredASCIIRenderer : MonoBehaviour
{
    public string asciiChars = "@#%+=:-. "; // Characters used for ASCII art
    public TextMeshProUGUI uiText; // TextMeshProUGUI component to display ASCII art
    private int asciiResolution = 16; // Resolution of ASCII grid

    void Start()
    {
        // Find all objects with the tag "ASCIIConvert"
        GameObject[] objectsToConvert = GameObject.FindGameObjectsWithTag("ASCIIConvert");
        Debug.Log($"Found {objectsToConvert.Length} objects to convert."); // Debug log

        foreach (GameObject obj in objectsToConvert)
        {
            // Check if the object is NOT part of the UI (i.e., it doesn't have a Canvas component)
            if (obj.GetComponent<Canvas>() == null)
            {
                // Get the SpriteRenderer to access the sprite's texture
                SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    Debug.Log($"Processing object: {obj.name}"); // Debug log
                    // Get the sprite's texture
                    Texture2D spriteTexture = renderer.sprite.texture;

                    // Disable the sprite renderer to hide the square
                    renderer.enabled = false;

                    // Generate and display the ASCII art for this object
                    GenerateASCIISprite(spriteTexture);
                }
                else
                {
                    Debug.LogWarning($"No SpriteRenderer found on {obj.name}"); // Warning log
                }
            }
            else
            {
                Debug.LogWarning($"Object {obj.name} is part of the UI and will be ignored."); // Warning log
            }
        }
    }

    void GenerateASCIISprite(Texture2D spriteTexture)
    {
        StringBuilder asciiArt = new StringBuilder();

        // Loop through each pixel of the sprite texture based on the defined resolution
        for (int y = 0; y < spriteTexture.height; y += asciiResolution)
        {
            for (int x = 0; x < spriteTexture.width; x += asciiResolution)
            {
                // Get the color of the pixel at (x, y)
                Color pixelColor = spriteTexture.GetPixel(x, y);

                // Calculate the brightness of the pixel (average of RGB values)
                float brightness = (pixelColor.r + pixelColor.g + pixelColor.b) / 3.0f;

                // Debug log for brightness
                Debug.Log($"Pixel at ({x},{y}) - Color: {pixelColor}, Brightness: {brightness}");

                // Map the brightness to an ASCII character index
                int charIndex = Mathf.FloorToInt(brightness * (asciiChars.Length - 1));
                charIndex = Mathf.Clamp(charIndex, 0, asciiChars.Length - 1); // Ensure within bounds

                // Convert pixel color to HTML color format (hexadecimal #RRGGBB)
                string hexColor = ColorUtility.ToHtmlStringRGB(pixelColor);

                // Append the ASCII character wrapped with the color tag
                asciiArt.Append($"<color=#{hexColor}>{asciiChars[charIndex]}</color>");
            }
            // After each row of pixels, add a new line in the ASCII art
            asciiArt.AppendLine();
        }

        // Log the generated ASCII art for debugging
        Debug.Log($"Generated ASCII Art:\n{asciiArt.ToString()}");

        // Display the generated ASCII art in the TextMeshProUGUI component
        uiText.text = asciiArt.ToString();
    }

}
