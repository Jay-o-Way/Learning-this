# Code name: Pass It On

Password manager, based on previous development with AutoIt.

## Features

GUI with:

- **ComboBox** or **AutoSuggestBox** to select (existing) data or create new subject by typing a new name
- Create, Edit, Delete **buttons**
- Controls to print:
  - subject (aka Title)
  - location **HyperlinkButton** `IsVisible=`
  - log-in name (often an e-mail address)
  - password
- Save and Cancel **buttons** to enter or dismiss changes
- **DorpDown** to select different sub-items ~and a number to indicate the displayed sub-item~. (example: subject "Outlook" can contain multiple e-mail accounts)
- Settings: **MenuBar** or something else?

## Open questions

For open questions, have a look at [Discussions](https://github.com/Jay-o-Way/Learning-this/discussions).

Answered questions:
<dl>
<dt>Languages</dt><dd>C#, XAML, JSON</dd>
</dl>

## To do, or not to do?

Based on the old work and the existing app, we can say the following.

| Subject                       | Y/M/N | Prio |
|-------------------------------|-------|------|
| Edit and Save passwords       | Y     | 1    |
| Backup/import data file       | Y     | 3    |
| Encrypted data storage        | M     | 2    |
| Main password for app         | M     | 2    |
| Have a Settings menu          | M     | 2    |
| Translation for UI strings    | M     | 3    |
| Backup data to online service | N     | Ø    |
| Have update check             | N     | Ø    |
