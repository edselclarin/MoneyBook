# MoneyBook

This is a simple tool to help you manage your financial accounts and remind you when things are due.

## Features

* Manually add transactions to an account or import them via QFX file (Quicken XML format) from you bank.
* Modify or delete existing transactions.
* Stage transactions into the account register to help project income and expenses.
* Reconcile staged transactions against newly imported transactions.
* Ability to backup and restore data via file.
* Colorized transactions to indicte Past Due and Due Soon.
* Dark Theme.

## Solution

This application is built with C# WinForms and backed by an SQL Server database.  It is structured into three projects:

* MoneyBook: Library containing models, database context, SQL statements, and data conversions.
* MoneyBookApi: Not used.
* MoneyBookTools: C# WinForms application.

## Screenshots

#### Main Window
![image](https://user-images.githubusercontent.com/30009438/213085856-9bdff37c-494c-44ef-8b2f-2ebb5d8802c8.png)

#### Menus
![image](https://user-images.githubusercontent.com/30009438/213086111-f862ea01-0516-45ac-9b89-6089745b129d.png)

#### Edit Transaction
![image](https://user-images.githubusercontent.com/30009438/213086171-dc163d68-d086-464a-86c2-67812766a0c3.png)

#### Tools Menu
![image](https://user-images.githubusercontent.com/30009438/213086210-7f105298-1215-4340-9d27-91de64ea614f.png)

#### Filtering and Sorting
![image](https://user-images.githubusercontent.com/30009438/213086245-df2cc5ea-24c7-4d37-ace6-f96363458c53.png)

![image](https://user-images.githubusercontent.com/30009438/213086253-be19972a-548f-46fe-94cb-40fb25ac1255.png)

## Usage

For help building and running this application, send email to edsel.clarin@yahoo.com.
