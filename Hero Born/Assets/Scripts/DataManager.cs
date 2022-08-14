using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataManager : MonoBehaviour, IManager
{
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    private string _dataPath;
    private string _textFile;
    private string _streamingTextFile;

    void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data/";
        // var path = Path.Combine("/Users", "harrison", "Chapter_12");
        // Debug.Log(_dataPath);
        _textFile = _dataPath + "Save_Data.txt";
        _streamingTextFile = _dataPath + "Streaming_Save_Data.txt";
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _state = "Data Manager initialized...";
        Debug.Log(_state);
        // FilesystemInfo();
        NewDirectory();
        // NewTextFile();
        // UpdateTextFile();
        // ReadFromFile(_textFile);

        WriteToStream(_streamingTextFile);
        ReadFromStream(_streamingTextFile);
    }

    // public void FilesystemInfo()
    // {
    //     Debug.LogFormat("Path separator character: {0}", Path.PathSeparator);
    //     Debug.LogFormat("Directory separator character: {0}", Path.DirectorySeparatorChar);
    //     Debug.LogFormat("Current directory: {0}", Directory.GetCurrentDirectory());
    //     Debug.LogFormat("Temporary path: {0}", Path.GetTempPath());
    // }

    public void NewDirectory()
    {
        if(Directory.Exists(_dataPath))
        {
            // Debug.Log("Directory already exists...");
            return;
        }
        // Directory.CreateDirectory(_dataPath);
        // Debug.Log("New directory created!");
        // Directory.Delete(_dataPath, true);
        // Debug.Log("Directory successfully deleted!");
    }

    public void NewTextFile()
    {
        if(File.Exists(_textFile))
        {
            Debug.Log("File already exists...");
            return;
        }
        File.WriteAllText(_textFile, "<SAVE DATA>\n\n");
        Debug.Log("New file created!");
    }

    public void UpdateTextFile()
    {
        if(!File.Exists(_textFile))
        {
             Debug.Log("File doesn't exists...");
            return;
        }
        File.AppendAllText(_textFile, $"Game started: {DateTime.Now}\n");
        Debug.Log("File updated successfully!");
    }

    public void ReadFromFile(string filename)
    {
        if(!File.Exists(filename))
        {
             Debug.Log("File doesn't exists...");
            return;
        }
        Debug.Log(File.ReadAllText(filename));
    }

    public void DeleteFile(string filename)
    {
        if(!File.Exists(filename))
        {
            Debug.Log("File doesn't exists or has already been deleted...");
            return;
        }
        File.Delete(filename);
        Debug.Log("File successfully deleted!");
    }

    public void WriteToStream(string filename)
    {
        if(!File.Exists(filename))
        {
            StreamWriter newStream = File.CreateText(filename);
            newStream.WriteLine("<Save Data> for HERO BORN \n\n");
            newStream.Close();
            Debug.Log("New file created with StreamWriter!");
        }
        StreamWriter streamWriter = File.AppendText(filename);
        streamWriter.WriteLine("Game ended: " + DateTime.Now);
        streamWriter.Close();
        Debug.Log("File content updated with StreamWriter!");
    }

     public void ReadFromStream(string filename)
    {
        if(!File.Exists(filename))
        {
            Debug.Log("File doesn't exists...");
            return;
        }
        StreamReader streamReader = new StreamReader(filename);
        Debug.Log(streamReader.ReadToEnd());
    }
}
