using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CertusCompanion
{
    [Serializable]
    class AppSave
    {
        #region AppSave Data
        internal List<AppData> SaveData { get; set; }
        internal AppData CurrentData { get; set; }
        internal AppData MostRecentSave { get; set; }
        #endregion

        //
        // Constructor (cannot be blank)
        public AppSave()
        {
            this.SaveData = new List<AppData>();
            this.CurrentData = new AppData();
            this.MostRecentSave = new AppData();
            SaveData.Capacity = 1;
        }

        //
        // Methods
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
        public void Save(string fileName)
        {
            string saveName = fileName;

            FileStream file = new FileStream(saveName, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, SaveData);
            file.Close();
        }
        public void Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                this.SaveData = (List<AppData>)formatter.Deserialize(fs);
                this.MostRecentSave = SaveData[SaveData.Count - 1];
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

        //
        // This class was for deserializing a different .dat type.
        // A workaround was found and it is no longer used but I
        // decided to keep it in the code for future reference
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
