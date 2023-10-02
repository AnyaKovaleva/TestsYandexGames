using System;
using System.Collections.Generic;
using Agava.YandexGames;
using Collection;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Initialization
{
    public static class CloudSave
    {
        private static CloudData _cloudData;

        public static event Action<CloudData> OnCloudDataRecieved;
        public static void GetCloudData(Action<CloudData> onCloudDataRecieved)
        {
            OnCloudDataRecieved = onCloudDataRecieved;
            PlayerAccount.GetCloudSaveData(HandleCloudData);
        }

        private static void HandleCloudData(string rawCloudData)
        {
            if (string.IsNullOrEmpty(rawCloudData))
            {
                Debug.LogError("Data from cloud is null");
                OnCloudDataRecieved?.Invoke(null);
                return;
            }

            _cloudData = JsonConvert.DeserializeObject<CloudData>(rawCloudData);
            OnCloudDataRecieved?.Invoke(_cloudData);
        }

        public static void SaveToCloud()
        {
            PlayerAccount.SetCloudSaveData(JsonConvert.SerializeObject(_cloudData));
        }

        public static void SetEnergyCatsStatuses(List<EnergyCat> energyCats)
        {
            if (_cloudData == null)
                _cloudData = new CloudData();

            _cloudData.EnergyCats = energyCats;
        }

        public static void IncrementNumOfRuns()
        {
            if (_cloudData == null)
                _cloudData = new CloudData();

            _cloudData.NumOfRuns++;
            Debug.Log("new num of runs " + _cloudData.NumOfRuns);
        }
        
        
    }
}