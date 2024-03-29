﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecTrail
{
    public static class PathDb
    {
        public static string GetPath(string nameDb)
        {
            string pathDbSqlite = string.Empty;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                pathDbSqlite = Path.Combine(pathDbSqlite, nameDb);
            } else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                pathDbSqlite = Path.Combine(pathDbSqlite, "..", "Library", nameDb);
            } else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                pathDbSqlite = Path.Combine(pathDbSqlite, nameDb);
            }

            return pathDbSqlite; 
        }
    }
}
