⚠️ IMPORTANT: Setup Instructions

If the project fails to build or shows "Missing Debug Target" errors, please apply the following fixes required by Windows Security policies:

    Unblock the Project (Fixes "Mark of the Web" Error)

Since this project was developed in a cross-platform environment (macOS VM), Windows may block the resource files (.resx).

Before extracting: Right-click the .zip file -> Properties -> Check Unblock -> Apply.

If already extracted: Right-click the Form1.resx file inside the project folder -> Properties -> Check Unblock.

    Shorten the File Path (Fixes "OS Max Path Limit" Error)

This project uses descriptive naming conventions which may exceed the Windows 260-character path limit if placed deep within subfolders (e.g., Downloads or Desktop).

Solution: Please move/extract the project folder to a root-level directory such as C:\Source\ or C:\Labs\.

    Fresh Build

After unblocking, please perform the following in Visual Studio:

Go to Build > Clean Solution.

Go to Build > Rebuild Solution.
