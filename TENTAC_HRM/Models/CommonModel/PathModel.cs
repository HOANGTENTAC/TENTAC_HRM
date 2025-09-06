using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TENTAC_HRM.Models.CommonModel
{
    public class PathModel
    {
        static PathModel()
        {
            //Check And Create Default Directory
            if (!Directory.Exists(AppDataLocal)) Directory.CreateDirectory(AppDataLocal);
            if (!File.Exists(SettingFilePath)) using (FileStream fs = new FileStream(SettingFilePath, FileMode.Create)) { }

            //Load Override Runtime
            LoadAllRuntime();
        }
        #region Attribute And Method Default
        //public static string RootSolutionPath { get; set; } =
        //    Directory.GetParent("Kyuyo_Meisai").Parent.Parent.FullName;
        //public static string AppDataLocal { get; set; } =
        //    $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Kyuyo_Meisai";        
        public static string AppDataLocal { get; set; } =
            $@"{Application.StartupPath}\Kyuyo_Meisai";
        public static string SettingFilePath { get; set; } =
            $@"{AppDataLocal}\Setting.ini";
        public static string DesktopPath { get; set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static void LoadAllRuntime()
        {
            var reload_runtime_excel_path = ReadIniFile(ExcelPathName);
            if (!string.IsNullOrEmpty(reload_runtime_excel_path)) ExcelPathValue = reload_runtime_excel_path;
        }
        public static void WriteIniFile(string section, string key, string value)
        {//Notice: section is Name Group
            var lines = new List<string>();
            bool sectionFound = false;
            bool keyFound = false;

            if (File.Exists(SettingFilePath))
            {
                foreach (var line in File.ReadLines(SettingFilePath))
                {
                    if (line.StartsWith($"[{section}]"))
                    {
                        sectionFound = true;
                        lines.Add(line);
                    }
                    else if (sectionFound && line.StartsWith("[") && line.EndsWith("]"))
                    {
                        sectionFound = false;
                        if (!keyFound)
                        {
                            lines.Add($"{key}={value}");
                            keyFound = true;
                        }
                        lines.Add(line);
                    }
                    else if (sectionFound && line.StartsWith($"{key}="))
                    {
                        lines.Add($"{key}={value}");
                        keyFound = true;
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }
            }

            if (!sectionFound)
            {
                lines.Add($"[{section}]");
            }

            if (!keyFound)
            {
                lines.Add($"{key}={value}");
            }

            File.WriteAllLines(SettingFilePath, lines);

            //Reload Runtime Variable
            LoadAllRuntime();
        }

        public static string ReadIniFile(string key)
        {
            foreach (var line in File.ReadLines(SettingFilePath))
            {
                if (line.Contains($"{key.Trim()}="))
                {
                    var keyValue = line.Split('=');
                    if (keyValue.Length == 2)
                    {
                        return keyValue[1].Trim();
                    }
                }
            }
            return null; // Trả về null nếu không tìm thấy key
        }
        #endregion
        #region GroupName Write Here
        public static string GroupSetting { get; set; } = "BasicSetting";
        #endregion

        #region Key And Value Write Here
        public static string ExcelPathName { get; set; } = "ExcelPath";
        public static string ExcelPathValue { get; set; } = DesktopPath; //Default is Desktop Path
        #endregion
    }
}
