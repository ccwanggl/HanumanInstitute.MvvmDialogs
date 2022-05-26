﻿using System.Collections.Generic;
using System.Linq;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs.Avalonia.Api;
using HanumanInstitute.MvvmDialogs.Avalonia;

namespace HanumanInstitute.MvvmDialogs.FrameworkDialogs.Avalonia;

internal abstract class FileDialogBase<TSettings, TResult> : FrameworkDialogBase<TSettings, TResult>
    where TSettings : FileDialogSettings
{
    internal FileDialogBase(IFrameworkDialogsApi api, IPathInfoFactory pathInfo, TSettings settings, AppDialogSettings appSettings)
        : base(api, pathInfo, settings, appSettings)
    {
    }

    protected void AddSharedSettings(FileApiSettings d)
    {
        // s.DefaultExtension
        // d.DereferenceLinks = s.DereferenceLinks;
        // d.CheckFileExists = s.CheckFileExists;
        // d.CheckPathExists = s.CheckPathExists;
        var s = Settings;
        d.Directory = s.InitialDirectory;
        d.InitialFileName = s.InitialFile;
        d.Filters = SyncFilters(s.Filters);
        d.Title = s.Title;
    }

    private static List<FileDialogFilter> SyncFilters(List<FileFilter> filters) =>
        filters.Select(
            x => new FileDialogFilter()
            {
                Name = x.NameToString(x.ExtensionsToString()), Extensions = x.Extensions
            }).ToList();
}
