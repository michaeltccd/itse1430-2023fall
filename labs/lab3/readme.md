# Character Creator (ITSE 1430)

## Version 3.1

In this lab you will update your Character Creator from the earlier lab to be a Windows Forms application.

## Skills Needed

- C#
  - Classes and Class Members
  - Collections
- Windows Forms
  - Forms and layout
  - Controls including TextBox, Button, Label and menus
  - Error Provider

## Story 0 - Set Up Solution

Create a new solution for the lab.

### Description

Create a new `Lab3` solution for your lab. Create a Windows Forms project for your UI.

- Select the `Windows Forms App` project template. Ensure it has the tags `C#`, `Linux` and `Windows`.
- Set the project name to `<name>.AdventureGame.WinHost`.
- Ensure the framework target is set to `.NET 6`.

Create a class library project for your business code.

- Select the `Class Library` project template. Ensure it has the tags `C#`, `Linux` and `Windows`.
- Set the project name to `<name>.AdventureGame`.
- Ensure the framework target is set to `.NET 6`.
- Add a reference to the business project so you have access to the business code.

For both projects go to the project's properties window. Navigate to `Application \ General` and change `Nullable` to `disable`.

*Note: Ensure you add file headers to the files.*

## Story 1 - Prepare the Character Class

Copy the character class to the new project and make some adjustments.

### Description

Copy the `Character` class and any related types that are needed into your business project.

Adjust the namespace to match the project name to avoid issues later.

Ensure the class has a `Validate` method that validates the instance is valid given the rules that were defined in the previous lab.

Override the `ToString` method to show the character's name, profession and race. This will be needed in the UI later.

*Note: Unless otherwise stated all the rules for a character remain as they were in the first lab.*

### Acceptance Criteria

- Class is properly declared.
- Class has proper documentation.
- Validation method properly validates an instance.

## Story 2 - Set Up Main Window

Create a main window for your new application.

### Description

Change some of the properties of the main window.

- Rename the main window class/file to `MainForm`.
- Set the following attributes.
  - Title should be `<name> Adventure Game` or similar title.
  - Default size should be 800 x 600.
  - Minimum size should be 300 x 200.
- Add a menu for navigating the application.

#### Exiting the Program

Create a new menu item for `File\Exit` with appropriate accelerator keys. The command should be assigned the shortcut key of `Alt+F4`.

When the command is executed close the main window and terminate the application.

#### Providing Help

Create a new menu item for `Help\About` with appropriate accelerator keys. The command should be assigned the shortcut key of `F1`.

When the command is executed show an About form centered in the parent. 

The form should show the following information:
- Product: `<name> Adventure Game`
- Company: Your name
- Version: `1.0.0`

Set these values at the project level. Do not hard code them in the UI.

### Acceptance Criteria

- Solution opens properly in Visual Studio and loads all projects.
- Project is properly named in repository.
- Code compiles cleanly.
- Main window is properly shown on startup.
- Can exit program, after confirmation.
- Can view About box for program.

## Story 3 - Display Characters

The main view of the UI will show the character roster.

### Description

- Drag and drop a [ListBox](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-4/controls-listbox.adoc) from the `Toolbox` onto the main window.
- Since this represents the character list set the control name appropriately.
- Set the `Dock` property to `Fill`.

Add a field to the main form of type `List<Character>`. This represents the characters that have been added.

Create a method to refresh the UI whenever there is a change made to the characters. This method will be needed later whenever a change is made to the list of characters.

The following code demonstrates how to get a `ListBox` to refresh from a collection.

```csharp
listbox.DataSource = null;
listbox.DataSource = character-list;
```

Create a method to get the selected character from the listbox. The `SelectedItem` property should provide this. This method will be needed later.

Refer to the [ListBox Control](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-4/controls-listbox.adoc) section of the book for more information on how to work with it.

### Acceptance Criteria

- Character roster resizes with main form.
- If the character roster is changed then the changes appear in the UI.
- Character information is properly shown in roster.

## Story 4 - Support Adding a New Character

Allow the user to create a new character.

### Description

Create a new menu item for `Character\New` with appropriate accelerator keys. The command should be assigned the shortcut key of `Ctrl+N`.

When the command is executed show a form to collect the character information. The form will have the following attributes.

- The title will be `Create New Character`.
- The form will be centered on the parent.
- The form will not be resizable and will appropriately fit the contents.
- The form will not have an icon, minimize or maximize buttons.
- Ensure all controls and labels are lined up properly.  

The form will display the fields from the `Character` class defined in the business project. For each field.

- Include an appropriate label.
- Use the appropriate control. For profession/race use a `ComboBox`.
- The fields should tab in a logical order.

Heroes are not average people so set each attribute to an initial value of `50`.

The combo boxes should not allow freeform text. Only the pre-defined options should be available.
Refer to the [ComboBox Control](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-4/controls-combobox.adoc) section of the book for information on how to use it.

The form will have a `Save` button that will save the character.
- Create an instance of the `Character` class and set the properties accordingly.
- Validate the newly created character using the `Character` class's method.
- If validation fails then prevent the form from closing.
- If validation succeeds then return to the main form and do the following.
  - The form will return the newly created character.
  - Add the new character to the character list.
  - Update the UI to show the character in the roster.

The form will have a `Cancel` button that will cancel the creation. No validation is done and no changes should be made.

### Acceptance Criteria

- When selected the form is shown.
- Attributes default to the appropriate value.
- Validation is handled properly.
- Saving saves the character and shows in the UI.
- Cancel closes the form without validation and without making any changes.

## Story 5 - Support Editing a Character

Allow the user to edit an existing character.

### Description

Create a new menu item for `Character\Edit` with appropriate accelerator keys. The command should be assigned the shortcut key of `Ctrl+O`.

When the command is selected get the currently selected character from the roster. If no character is selected then do nothing.

If a character is selected then show show the character form again with the selected character information already populated. The form will behave the same as when creating a new character with the following exceptions.

- Change the form title to `Edit Character`.
- When the form is loaded the data should be pre-populated based upon the currently selected character's values.
- When saving the character the existing character instance should be updated instead.
- Ensure the character is still valid.
- The roster should be refreshed after saving to reflect any changes in the name.

### Acceptance Criteria

- Selecting a character in the roster and then excuting the command properly displays the character in the form.
- Saving the character updates the existing character.
- Roster is refreshed after save.
- Cancelling the edit does not change data.

## Story 6 - Support Deleting a Character

Allow the user to delete an existing character.

### Description

Create a new menu item for `Character\Delete` with appropriate accelerator keys. The command should be assigned the shortcut key of `Del`.

When the command is selected get the currently selected character from the roster. If no character is selected then do nothing.

If a character is selected then display a confirmation message that asks if the user wants to delete the given character. Include the character name in the message.

The character roster should be refreshed after saving to reflect any changes in the name.

### Acceptance Criteria

- Selecting a character in the roster and then excuting the command prompts for confirmation with the character's name.
- Confirming the message deletes the character and refreshes the list.
- Cancelling the confirmation does not change anything.

## Story 7 - Support Error Provider

Add the `ErrorProvider` to the add (and edit) forms for characters.

### Description

Update the add (and edit if different) forms to use the `ErrorProvider` to report errors in fields.

- Validate each field following the rules for validation of that field (e.g. required, range, etc)
- If a field has an invalid value then display an error next to it.
- When validating the user should be able to navigate to other controls but an error should be shown next to the invalid fields.
- When the user attempts to save the changes then ensure all the controls are valid before attempting to save.
- If the user cancels the form then no validation errors should occur.

### Acceptance Criteria

- Entering an invalid value in a field causes the error icon to display when tabbing away.
- User can navigate away from field even if invalid.
- Attempting to save when a field is invalid should display the error icon(s) appropriately.
- Cancel closes the form without validation and without making any changes.

## Hints

- DO NOT worry about the field names for controls you do not programmatically use (e.g. menu items). The defaults are fine.
- USE descriptive field names for controls you will work with in code (e.g. text boxes).
- USE descriptive method names for event handlers (e.g. `OnFileExit` instead of `menuItem1_Clicked`).

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in Canvas by providing the link to the Github repository.
