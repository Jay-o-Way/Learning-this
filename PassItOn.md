# Code name: Pass It On

Password manager, based on previous development with AutoIt.

## Features

GUI with:

- **ComboBox** to select existing data, or create new subject by typing a new name
- **DropDown** to select different sub-items. (example: subject "Outlook" can contain multiple e-mail accounts)
- Create, Edit, Delete **buttons**
- Controls to print:
  - subject (aka Title)
  - location **hyperlinkButton**
  - log-in name (often an e-mail address)
  - password
- Save and Cancel **buttons** to enter or dismiss changes
- **MenuBar**

## Open questions

For open questions, have a look at [Discussions](https://github.com/Jay-o-Way/Learning-this/discussions).

Answered questions:
<dl>
<dt>Languages</dt><dd>C#, XAML, JSON</dd>
</dl>

## To do, or not to do?

Based on the old work of the existing (AutoIt) app, we can say the following.

| Function                      | Y/M/N | Prio |
|-------------------------------|-------|------|
| Edit and Save passwords       | Y     | 1    |
| Have a Settings menu          | Y     | 2    |
| Backup/import data file       | Y     | 3    |
| Encrypted data storage        | M     | 1    |
| Main password for app         | M     | 2    |
| Translation for UI strings    | M     | 2    |
| Backup data to cloud          | N     | Ø    |
| Have update check             | N     | Ø    |
