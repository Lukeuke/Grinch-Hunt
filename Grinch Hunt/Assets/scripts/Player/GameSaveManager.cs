using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public List <GameObject> objects = new List<GameObject>();

    /*public void SaveScriptables() {
        for (int i = 0; i < objects.Count; i++) {
            FileStream file = File.Create(Application.presistentDataPath + 
                string.Format("/{0}.dat", i));

                BinaryFormatter binary = new BinaryFormatter();
                var json = JsonUtility.ToJson(objects[i]);
                binary.Serialize(file, json);
                file.Close();
        }
    } */
}
