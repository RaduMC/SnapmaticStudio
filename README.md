# Snapmatic Studio#

This is a simple application designed to preview and export pictures made with your phone in GTA V for PC.
At the time of this writing, uploading pictures to R* Social Club was not working for some people.
You can use this as a workaround, but it will also help if you just want to share your pictures by other means.

Important! The application will only access Snapmatic image files. It doesn't need anything else from your GTA V profile in order to export pictures.


### Loading files ###
Use the File menu to start loading pictures.

Opening a folder will clear the current list and load all Snapmatic pictures in it, but not subfolders.
By default the application will look your Documents for \Rockstar Games\GTA V\Profiles\ and select the first profile. Otherwise you can browse wherever you like.

Loading a single file will append it to the current list.


### Managing pictures ###
You can sort pictures by clicking on column headers. Click twice to change the order.
Highlighting a picture entry will load it in the preview window.

Use the checkboxes to specify the pictures you want to export.
You can also highlight multiple files with Ctrl or Shift + click and then use the right-click menu to select them.

You can rename a title by clicking twice on it (not a fast double-click).
The new title is only used when exporting the picture, if you have activated this setting. It will not be saved in the original Snapmatic file, these will always remain untouched.


### Application settings ###
The Options menu provides export and preview settings. All settings are saved for the next session.

"Use title as filename" is the previously mentioned option that will export your pictures using their title instead of the original PGTA5########## filename.
Activating this will enable "Add time & date to filename" in order to make filenames unique, which is recommended unless you manually enter unique titles.
Note that the application will not overwrite any files that already exist.

"Export metadata log" will save a text file along with each picture that contains game-related data such as picture coordinates and modes.
You can also view this data in the preview window by activating "Show metadata overlay".

The "Zoom image" option will automatically scale pictures when you resize the window.
"Resize window to fit image" is a one-click command that will resize the application window to match the original picture size. Note that the file list panel is not resized by this.


### Exporting ###
To export pictures use the File menu or right-click menu to export either all or just the ones selected.
You can save them in the same path as Snapmatic files or you can choose a custom destination.

The app will extract image data "as is", without altering or re-encoding it. So far I have only encountered JPEG data, but the code can handle unknown types.

Snapmatic files also contain additional data that is unknown at this point. At first glance it looks like 3D data which could be somehow related to the map.
