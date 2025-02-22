﻿namespace NAPS2.Platform;

internal interface ISystemCompat
{
    bool IsWiaDriverSupported { get; }

    bool IsTwainDriverSupported { get; }

    bool IsAppleDriverSupported { get; }

    bool IsSaneDriverSupported { get; }

    bool IsEsclDriverSupported { get; }
    
    bool SupportsShowPageNumbers { get; }
    
    bool SupportsProfilesToolbar { get; }
    
    bool SupportsButtonActions { get; }
    
    bool SupportsSingleInstance { get; }

    bool CanUseWin32 { get; }

    bool CanEmail { get; }

    bool CanPrint { get; }

    bool ShouldRememberBackgroundOperations { get; }

    bool RenderInWorker { get; }

    bool SupportsWinX86Worker { get; }

    string[] ExeSearchPaths { get; }

    string[] LibrarySearchPaths { get; }

    string TesseractExecutableName { get; }

    string PdfiumLibraryName { get; }

    string[]? SaneLibraryDeps { get; }

    string SaneLibraryName { get; }

    IntPtr LoadLibrary(string path);

    IntPtr LoadSymbol(IntPtr libraryHandle, string symbol);

    string GetLoadError();

    IDisposable? FileReadLock(string path);

    IDisposable? FileWriteLock(string path);

    void SetEnv(string name, string value);
}