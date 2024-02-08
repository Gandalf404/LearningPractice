using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPractice_Launcher_
{
    public class LauncherHandler
    {
        //public static List<string> GetHardwareInfo(string WIN32_Class, string ClassItemField)
        //{
        //    List<string> result = new List<string>();
        //    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + WIN32_Class);
        //    switch (ClassItemField)
        //    {
        //        case "Capacity":
        //            int Capacity = 0;
        //            foreach (ManagementObject m in searcher.Get()) Capacity += Convert.ToInt32(Math.Round(Convert.ToDouble(m[ClassItemField]) / 1024 / 1024));
        //            result.Add(Capacity.ToString() + " Мб");
        //            break;
        //        default:
        //            foreach (ManagementObject obj in searcher.Get()) result.Add(obj[ClassItemField].ToString().Trim());
        //            break;
        //    }
        //    return result;
        //}

        public enum LauncherStatus
        {
            Ready,
            Failed,
            DownloadingApp,
            DownloadingUpdate
        }
        public struct AppVersion
        {
            public static AppVersion zeroVersion = new AppVersion(1, 0, 0);

            private uint _majorVersion;
            private uint _minorVersion;
            private uint _subMinorVersion;

            public bool IsVersionDifferent(AppVersion currentVersion)
            {
                if (_majorVersion > currentVersion._majorVersion)
                {
                    return true;
                }
                else
                {
                    if (_minorVersion > currentVersion._minorVersion)
                    {
                        return true;
                    }
                    else
                    {
                        if (_subMinorVersion > currentVersion._subMinorVersion)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public override string ToString()
            {
                return $"{_majorVersion}.{_minorVersion}.{_subMinorVersion}";
            }

            public AppVersion(uint majorVersion, uint minorVersion, uint subMinorVersion)
            {
                _majorVersion = majorVersion;
                _minorVersion = minorVersion;
                _subMinorVersion = subMinorVersion;
            }

            public AppVersion(string version)
            {
                string[] versionStrings = version.Split('.');

                if (versionStrings.Length != 3)
                {
                    _majorVersion = 1;
                    _minorVersion = 0;
                    _subMinorVersion = 0;
                    return;
                }
                _majorVersion = uint.Parse(versionStrings[0]);
                _minorVersion = uint.Parse(versionStrings[1]);
                _subMinorVersion = uint.Parse(versionStrings[2]);
            }

            public AppVersion(Models.Application.Version version)
            {
                string[] versionStrings = version.Version1.ToString().Split('.');

                _majorVersion = uint.Parse(versionStrings[0]);
                _minorVersion = uint.Parse(versionStrings[1]);
                _subMinorVersion = uint.Parse(versionStrings[2]);
            }
        }
    }
}
