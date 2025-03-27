using UnityEngine;

public class ArduinoReceiver : MonoBehaviour
{
    public SerialController serialController; 
    public int receivedValue; 

    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    void Update()
    {
        string message = serialController.ReadSerialMessage(); // Read Arduino data

        if (message != null)
        {
            Debug.Log("🔍 Raw Data: [" + message + "]"); // Print the exact data received

            message = message.Trim(); // Remove hidden characters

            if (int.TryParse(message, out int value)) 
            {
                receivedValue = value; // Update variable
                Debug.Log("✅ Updated Variable: " + receivedValue);
            }
            else
            {
                Debug.LogError("❌ Parsing Failed: " + message);
            }
        }
    }
}
