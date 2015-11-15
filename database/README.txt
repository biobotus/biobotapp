Tutorial on how to install biobots database for developpment mode.

***************************************
Postgresql database setup
***************************************
Follow the steps for windows users:
1) Download EnterpriseDB from the postgresql site: http://www.postgresql.org/
	Note: do not download PgAdmin, download the EnterpriseDB, this download also contians the PgAdmin client for windows users.
2) Install pgAdmin using the EnterpriseDB installer. Skip the following steps a), b) and so on if you are not new in installing pgAdmin
	when prompt:
		a) enter admin as superuser password.
		b) use default port 5432.
		c) check the add Stack builder when installation is finished
3) Using the stack builder installation
	a) under Categories, Database Drivers check the psqlODBC using the correct system architecture
	b) complete the installation
4) Execute pgAdmin
5) Connect to the localhost database
	a) Enter admin as the password when prompt
6) Create new database
	a) Expand localhost:5432 server
	b) Right click Databases
	c) Click create new database
	d) Under name enter: biobot
	e) Hit enter or press Ok

******************************************
biobot database import
******************************************
Steps to import biobots database in local host
1) Select biobot database (the new created database in step 6 in database setup) and press the execute sql query or ctrl+e
2) Drag and drop the initDatabase file in the query window (lines will be automaticly entered)
3) Execute the query by pressing F5. If this doesnt work press F6
4) Right click biobot database and select Restore
5) Browse to the following dump file: \biobotapp\database\dump\2015-09-10\biobot-schema-nodata.dump
	a) Dont forget to set the file filter to All files (*.*)
6) Click restore once the file has been chosen
7) Have fun !


