
This is fork of https://github.com/tobiasstrebitzer/FireFile

Here my intension is to create desktop util independent on web server to maintain file saving.

https://DocX@github.com/DocX/FireFile.gitChanges to original FireFile extension:
* add ability to enable site by user and setup local URL of tool

New tool:
* write .NET simple application for handling FireFile requests 


INSTALATION
-----------

1) Get repository copy in Downloads link

2) Install firefile.xpi from release folder into Firefox with Firebug installed.

3) Get HttpFileSaverWin.zip from release folder and unzip into your home directory.

USE
---

1) Run Firefox and open site which CSS you want to modify or develop.

2) Run HttpFileSaverWin application. Choose port and name of virtual subfolder. You can also keep defaults. Make sure you choose web folder root. It is directory, where "/" of the website is placed. Hit "Start" button.

3) Copy URL from application.

4) In Firefox, open Firebug. Go to HTTP tab and there open in right panel (CSS inspector) tab named "FireFile".

5) Click on tab's arrow to show popup menu. Choose "manual enable". In window put value of clipboard (URL address from windows tool).

6) Enjoy siply CSS development.




