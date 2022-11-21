using System;
using System.Management;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Domain.Entities
{
    /*
    public class Asset
    {
        // UUID for asset
        public Guid Id { get; set; }
        // Hardware Hash
        public string HardwareHash { get; set; }
        // Computer system name 
        public string CName { get; set; }
        // Computer system model
        public string CModel { get; set; }
        // Computer system manufactuter
        public string CManufacturer { get; set; }
        // Computer system type (CPU arch)
        public string CType { get; set; }
        // Operating System name
        public string OSName { get; set; }
        // Operating System version
        public string OSVersion { get; set; }
        // Operating System arch
        public string OSArch { get; set; }
        // Computers IP address
        public string IPAddress { get; set; }
        // Computers MAC address
        public string MACAddress { get; set; }
        public Asset()
        {
            CName = GetManagementField(
                GetManagementCollection("SELECT * FROM Win32_ComputerSystemProduct"),
                "UUID"
            );
            
            CModel= GetManagementField(
                GetManagementCollection("SELECT * FROM Win32_MotherBoardDevice"),
                "DeviceID"
            );

            CManufacturer = GetManagementField(
                GetManagementCollection("SELECT * FROM Win32_Processor"),
                "ProcessorId"
            );

            CType = GetManagementField(
                GetManagementCollection("SELECT * FROM Win32_ComputerSystem"),
                "SystemType"
            );

            this.HardwareHash = BuildHardwareHash();
        }

        public Asset(string _CName, string _CModel, string _CManufacturer, string _CType, string _OSName, string _OSVersion, string _OSArch, string _IPAddress, string _MACAddress)
        {
            HardwareHash = "Unknown";
            CName = _CName;
            CModel = _CModel;
            CManufacturer = _CManufacturer;
            CType = _CType;
            OSVersion = _OSVersion;
            OSArch = _OSArch;
            IPAddress = _IPAddress;
            MACAddress = _MACAddress;
        }

        private string BuildHardwareHash()
        {
            try
            {
                string SystemIdHash = GetManagementField(
                    GetManagementCollection("SELECT * FROM Win32_ComputerSystemProduct"),
                    "UUID"
                );

                string MotherBoardIdHash = GetManagementField(
                    GetManagementCollection("SELECT * FROM Win32_MotherBoardDevice"),
                    "DeviceID"
                );

                string ProcessorIdHash = GetManagementField(
                    GetManagementCollection("SELECT * FROM Win32_Processor"),
                    "ProcessorId"
                );

                return CreateHash(SystemIdHash + MotherBoardIdHash + ProcessorIdHash);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }

        private ManagementObjectCollection GetManagementCollection(string query)
        {
            ManagementObjectSearcher hardwareObjectSearcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection hardwareObjectCollection = hardwareObjectSearcher.Get();

            return hardwareObjectCollection;
        }

        private string GetManagementField(ManagementObjectCollection managementObjectCollection, string field)
        {
            string queryResult = "";

            foreach (ManagementObject obj in managementObjectCollection)
            {
                queryResult = obj[field].ToString();
                break;
            }

            return queryResult;
        }

        private string CreateHash(string input)
        {
            StringBuilder stringResult = new StringBuilder();

            Encoding enc = Encoding.UTF8;
            byte[] hashResult = SHA256.Create().ComputeHash(enc.GetBytes(input));
            
            foreach (byte b in hashResult)
            {
                stringResult.Append(b);
            }

            return stringResult.ToString();
        }
    }
    */
}