﻿using Microsoft.Extensions.FileProviders;

namespace SalesPro.Plugin.Vsto;

public class VstoFileInfo : IFileInfo
{
    private readonly string filePath;
    private readonly string basePath;

    public VstoFileInfo(string basePath, string filePath)
    {
        this.basePath = basePath;
        this.filePath = filePath;
    }

    public string FullPath => Path.Join(basePath, filePath);

    public bool Exists => File.Exists(FullPath);

    public bool IsDirectory => false;

    public DateTimeOffset LastModified
    {
        get
        {
            return File.GetLastWriteTime(FullPath);
        }
    }

    public long Length
    {
        get
        {
            return File.ReadAllBytes(FullPath).Length;
        }
    }

    public string Name => Path.GetFileName(FullPath);

    public string PhysicalPath => string.Empty;

    public Stream CreateReadStream()
    {
        return File.OpenRead(FullPath);
    }
}