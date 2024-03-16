using System;
using System.IO;

[Serializable]
public class SoundDataToSave : IDataSaveble
{
    public bool musicStatus;
    public bool soundStatus;

    public SoundDataToSave()
    {
        musicStatus = true;
        soundStatus = true;
    }

    public void LoadData(BinaryReader binaryReader)
    {
        musicStatus = binaryReader.ReadBoolean();
        soundStatus = binaryReader.ReadBoolean();
    }

    public void SaveData(BinaryWriter binaryWriter)
    {
        binaryWriter.Write(musicStatus);
        binaryWriter.Write(soundStatus);
    }
}