# Welcome to Petz EZLoader

DISCLAIMER: 
PetzEL is designed to modify content in your petz Resource folders, so before using it BACK UP THOSE FOLDERS. I am not responsible if this program overwrites or deletes any important files you decided to store in those folders, or otherwise breaks your game.

## Installation Instructions:

IMPORTANT: If your Petz .exe is configured to "Run as Adimistrator", PetzEL must also be run as administrator! Otherwise PetzEL will not be able to automatically start the game.

To install PetzEL, simply extract the PetzEL installation .zip into any non-Progam Files directory, such as your "Documents" folder. Upon first launch, the program will automatically open the settings menu. There, you will be prompted to select the .exe file for the Petz/Babyz game you wish to use with PetzEL. PetzEL currently supports Petz 3, 4, 5 and Babyz. After that, you can adjust the settings to you liking, then click "Save and Start Petz" to launch the game. 

Once you have completed this inital setup, PetzEL will not open the setttings menu and skip straigt to loading the game unless the "Always Open Settings" option is checked. However, you can always open the settings menu again by double clicking the "modify_setting.bat" file included in the installation directory.

In order for the PetzEL seasons feature to work properly, it is reccomended that you alway use PetzEL to launch your game. If you'd like, you can create a shortcut to PetzEL and rename it to whichever game version you're running, and change the icon to one of the included Petz icon files

If you wish to use PetzEL with more than one P.F. Magic game, you can have multiple installations on one computer, all configured to run different games. Just make sure the files being loaded match the game version you're running!

## Seasons Instructions

PetzEL isn't just a content management system. It actually adds new features to the game! By checking your computers date and time and automatically swapping out playscenes before loading the game, it creates the illusion that Petz 3/4 and Babyz have real time seasons and weather. 

Setting up this feature is easy. Simply copy the playscenes you wish to be used for each season and/or time of day into the corrosponding folder in the SeasonalArea directory and PetzEL will handle the rest! You can also tweak the seasonal start and end date and sunrise/sunset times to better match the area you live, if you'd like 

Since I am not an artist, these folders current come empty. However, hopefully I will be able to convince one of the numerous talanted artist in the petz community to create a set of P.F. match playscenes that I can distribute with this mod in the future!

Note: If seasons are disabled, PetzEL will load the files in the summer directory, and if day/night is disabeld it will load the files in the day directory. If both are disabled, it skips changing the playscenes altogether.

## Bulk Loading Instructions

Have tons of custom Petz content to manage? Stick of having to copy files back and forth out your game? Well, PetzEL is here to help! With bulk loading, PetzEL will enable you to add and remove entire folders full of content from the Resource folder, all with the click of a button!

To get started, create a new folder in the "Files" directory. Then, sort the files you want to add into their repective resource folders. PetzEL will default to including any new content you add, so next time you start the game, the new files should be there. 

To remove content, simply open up the PetzEL setting and move whichever folder you'd like to remove from the "Remove" section. PetzEL will then automatically remove the files in those folders from your game directory.

Note: if you wish to delete a folder in your PetzEL directory, make sure to mark it as Revmoved from within PetzEL first! Otherwise, you will have to remove the content from your game manually, as PetzEL only removes files contained within the folders in its "Removed" section, and ignores all other files. 

## Tips and Tricks

Content is loaded in the following order: 
Season Area > Remove Files > Included Files, in the order they are listed in the setting page

PetzEL supports OW breeds! However, if you remove a folder containing OW breeds, make sure you have a folder containing the original version of those breeds in the included files. Otherwise, PetzEL won't know to replace the originals

## Info 

README file version 1.0

This software was created by skissors @ Alive Enough, with some help from her lovely partner Kyle <3
https://oodlecat.neocities.org/
