⚠️ IMPORTANT: Setup Instructions

If the project fails to build or shows "Missing Debug Target" errors, please apply the following fixes required by Windows Security policies:

    Unblock the Project (Fixes "Mark of the Web" Error)
Since this project was developed in a macOS environment (via VM), Windows may automatically block resource files (.resx) for security reasons. To ensure the project builds correctly, please follow these steps:

Option 1: Before Extracting (Recommended)

Right-click the downloaded .zip file.

Select Properties.

Check the Unblock checkbox at the bottom and click Apply.

Option 2: If Already Extracted

If you have already extracted the files, you must manually unblock the .resx files within the project folder. Right-click → Properties → Unblock for the following:

    Form1.resx

    Form2.resx

    Tip: You can also unblock all files at once by opening PowerShell in the project folder and running:

    Get-ChildItem -Recurse | Unblock-File

:

    Shorten the File Path (Fixes "OS Max Path Limit" Error)

This project uses descriptive naming conventions which may exceed the Windows 260-character path limit if placed deep within subfolders (e.g., Downloads or Desktop).

Solution: Please move/extract the project folder to a root-level directory such as C:\Source\ or C:\Labs\.

    Fresh Build

After unblocking, please perform the following in Visual Studio:

Go to Build > Clean Solution.

Go to Build > Rebuild Solution.
