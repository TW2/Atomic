You have to configure the FFmpeg folder like that :

```
+-FFmpeg
+---bin
+-----x64 (here are DLLs for FFmpeg x64)
+-----x86 (here are DLLs for FFmpeg x86)
```

You have to configure the MediaInfo folder like that :

```
+-MediaInfo
+---bin
+-----x64 (here is DLL for MediaInfo x64)
+-----x86 (here is DLL for MediaInfo x86)
```

The program will load the right DLLs for your platform.
