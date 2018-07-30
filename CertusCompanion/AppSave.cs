using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    class AppSave
    {
        private List<AppData> saveData;
        private AppData currentData;
        private AppData mostRecentSave;

        internal List<AppData> SaveData { get => saveData; set => saveData = value; }
        internal AppData CurrentData { get => currentData; set => currentData = value; }
        internal AppData MostRecentSave { get => mostRecentSave; set => mostRecentSave = value; }

        // constructor
        public AppSave()
        {
            this.SaveData = new List<AppData>();
            this.CurrentData = new AppData();
            this.MostRecentSave = new AppData();
            SaveData.Capacity = 1;
        }

        // methods
        public void AddSave(AppData dataToSave)
        {
            this.CurrentData = dataToSave;
            if (SaveData.Count == 1)
            {
                SaveData.RemoveAt(0);
            }
            SaveData.Add(dataToSave);
        }

        public void RemoveAllSaveData()
        {
            SaveData.Clear();
        }

        // place within a try
        public void Save(string fileName)
        {
            string saveName = fileName;

            FileStream file = new FileStream(saveName, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, SaveData);
            file.Close();
        }

        // place within a try
        public void Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                // Construct a BinaryFormatter and use it 
                // to deserialize the data from the stream.
                BinaryFormatter formatter = new BinaryFormatter();

                // Construct an instance of our the
                // Version1ToVersion2TypeSerialiationBinder type.
                // This Binder type can deserialize a Version1Type  
                // object to a Version2Type object.

                //formatter.Binder = new Version1ToVersion2DeserializationBinder();

                this.SaveData = (List<AppData>)formatter.Deserialize(fs);
                this.MostRecentSave = SaveData[SaveData.Count - 1]; // will get the newest save from the list
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public int SaveCount()
        {
            int count;

            count = this.SaveData.Count;

            return count;
        }

        sealed class Version1ToVersion2DeserializationBinder : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                Type typeToDeserialize = null;

                typeName = typeName.Replace("ValueFilter", "CertusCompanion");
                assemblyName = assemblyName.Replace("ValueFilter", "CertusCompanion");

                // The following line of code returns the type.
                typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                    typeName, assemblyName));

                return typeToDeserialize;
            }
        }
    }
}
