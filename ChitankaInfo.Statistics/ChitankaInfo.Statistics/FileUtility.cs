﻿using System;
using System.IO;
using System.IO.Compression;

namespace ChitankaInfo.Statistics
{
    public static class FileUtility
    {
        public static void ZIPFiles(string sourceDirectory, string zipFileName, CompressionLevel compressionLevel, bool includeBaseDirectory)
        {
            try
            {
                ZipFile.CreateFromDirectory(sourceDirectory, zipFileName, compressionLevel, includeBaseDirectory);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create zip file for the source directory " + sourceDirectory, ex);
            }
        }


        public static void UnZIPFiles(string zipPath, string extractPath)
        {
            try
            {
                using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
                {
                    archive.ExtractToDirectory(extractPath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to unzip package " + zipPath + " to " + extractPath, ex);
            }
        }

        public static void DeleteDirectory(string directoryToDelete)
        {
            System.IO.DirectoryInfo dirInfo = new DirectoryInfo(directoryToDelete);
            dirInfo.Delete(true);
        }
    }
}
