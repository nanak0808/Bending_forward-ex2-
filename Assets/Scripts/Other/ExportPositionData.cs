using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExportPositionData : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;
    [SerializeField] private int trialNum = 1;
    [SerializeField] private int subjectNum = 0;
    [SerializeField] private bool stopExport = false;
    private float interval = 0.5f;
    private float timer = 0f;
    private List<string> lines = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        lines.Add("Time,Trial,ExpansionRate,LeftHandX,LeftHandY,LeftHandZ,RightHandX,RightHandY,RightHandZ");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            if (stopExport)
            {
                return; // If stopExport is true, do not record positions
            }
            RecordHandPositions();
        }
    }

    void RecordHandPositions()
    {
        Vector3 leftPos = leftHand.position;
        Vector3 rightPos = rightHand.position;
        float time = Time.time;
        float expansionRate = rightHand.GetComponent<ChangeHandTrackPosition>().expansion_rate;

        string line = $"{time:F2},{trialNum},{expansionRate},{leftPos.x},{leftPos.y},{leftPos.z},{rightPos.x},{rightPos.y},{rightPos.z}";
        lines.Add(line);

        // Debug.Log(line);
    }

    void OnApplicationQuit()
    {
        string directoryPath = @"C:\Users\cogni\Kido_Unity_data(exp2)";
        string fileName = $"hand_positions_{subjectNum}.csv";
        string filePath = Path.Combine(directoryPath, fileName);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        File.WriteAllLines(filePath, lines);
        Debug.Log("Now exporting...");
    }
}
