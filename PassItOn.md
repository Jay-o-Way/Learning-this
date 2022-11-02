# Code name: Pass It On

Password manager, based on previous development with AutoIt.

## GUI

### Menu

| Control    | Function                                        |
|:-----------|:------------------------------------------------|
| App        |
| **Info**   | open this Project info page                     |
| **Close**  | close the app                                   |
| Data       |
| **Create** | create new subject, starting with ComboBox text |
| **Edit**   | exit selected subject                           |
| **Delete** | delete selected subject                         |
| **Import** | import data from file                           |
| **Export** | export data to file                             |

### Display data

![Screenshot of display area.](images/PIO-screenshot.png)

| Control           | Function                                                         |
|:-------------------|:------------------------------------------------------------------|
| ComboBox          | select existing data, or create new subject by typing a new name |
| TextBox           | display location                                                 |
| Button            | to open location                                                 |
| ComboBox          | select field "name" (often an e-mail address)                    |
| TextBox           | display password                                                 |
| **Create** button | create new subject, starting with ComboBox text                  |
| **Edit** button   | exit selected subject                                            |
| **Delete** button | delete selected subject                                          |
| **Save** button   | confirm input                                                    |
| **Cancel** button | dismiss changes                                                  |

## To do, or not to do?

Based on the old work of the existing (AutoIt) app, we can say the following.

| Function                   | Y/M/N | Prio |   |
|-----------------------------|--------|-------|----|
| Edit and Save passwords    | Y     | 1    |   |
| Have a Settings menu       | Y     | 2    | ✔ |
| Backup/import data file    | Y     | 3    |   |
| Encrypted data storage     | M     | 1    |   |
| Translation for UI strings | M     | 2    |   |
| Main password for app      | M     | 3    |   |
| Backup data to cloud       | N     | Ø    |   |
| Have update check          | N     | Ø    |   |

## Questions

For open questions, have a look at [Discussions](discussions/) in this repo.
Feel free to ask more or give me advice.

Answered questions:
<dl>
<dt>Languages</dt><dd>C#, XAML, JSON</dd>
</dl>
