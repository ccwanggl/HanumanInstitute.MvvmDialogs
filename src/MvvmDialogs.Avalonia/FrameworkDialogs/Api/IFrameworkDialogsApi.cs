﻿using MessageBox.Avalonia.Enums;

namespace HanumanInstitute.MvvmDialogs.FrameworkDialogs.Avalonia.Api;

/// <summary>
/// Wrapper around Win32 dialogs API that can be replaced by a mock for testing.
/// </summary>
internal interface IFrameworkDialogsApi
{
    Task<ButtonResult> ShowMessageBox(Window owner, MessageBoxApiSettings settings);
    Task<string[]?> ShowOpenFileDialog(Window owner, OpenFileApiSettings settings);
    Task<string?> ShowSaveFileDialog(Window owner, SaveFileApiSettings settings);
    Task<string?> ShowOpenFolderDialog(Window owner, OpenFolderApiSettings settings);
}