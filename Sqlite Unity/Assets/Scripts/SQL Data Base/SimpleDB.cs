using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;

public class SimpleDB : MonoBehaviour
{
    public InputField nameInput;
    public InputField typeInput;
    public Text weaponList;

    //name of the database
    private string dbName = "URI = file:Inventory.db";

    void Start()
    {
        //Run the method to create the table
        //CreateDB();

        //Method to add a weapon (WE WILL CHANGE THIS TO HAVE IT BE ON A BUTTON OR BY TYPING OR WHATEVER)
        //AddWeapon("Silver Sword", 30);

        //display existing weapon list
        //DisplayAllWeapons();
    }

    //method to create a table if it doesn´t exist already
    public void CreateDB()
    {
        //Create the db connection
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Set up an object (Called "Command") to allow db control
            using (var command = connection.CreateCommand())
            {
                //Create a table called weapons if it doesn´t exist already
                //it has 2 fields: name (up to 20 characters) and damage (an integer)
                command.CommandText = "CREATE TABLE IF NOT EXISTS weapons (name VARCHAR(30), type VARCHAR(30));";
                command.ExecuteNonQuery(); //This runs the SQL command
                Debug.Log("New Table Created.");
            }
            connection.Close();
        }
        DisplayAllWeapons();
    }

    //method to create a table if it doesn´t exist already
    public void DeleteDB()
    {
        //Create the db connection
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Set up an object (Called "Command") to allow db control
            using (var command = connection.CreateCommand())
            {
                //Create a table called weapons if it doesn´t exist already
                //it has 2 fields: name (up to 20 characters) and damage (an integer)
                command.CommandText = "DROP TABLE weapons;";
                command.ExecuteNonQuery(); //This runs the SQL command
            }
            connection.Close();
        }
        DisplayAllWeapons();
    }


    //This method will add a weapon. The parameters accept a name and damage
    public void AddWeapon()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Set up an object (Called "Command") to allow db control
            using (var command = connection.CreateCommand())
            {
                //Write the SQL command to insert a record with the values passed in to this method.
                //statement syntax: "INSENT INTO table name (field1, field2) VALUES ('value1', 'value2');"
                command.CommandText = "INSERT INTO weapons (name, type) VALUES ('" + nameInput.text + "', '" + typeInput.text + "');";
                command.ExecuteNonQuery(); //This runs the SQL command
            }
            connection.Close();
        }
        DisplayAllWeapons();
    }


    //Displays all data of the entire table
    public void DisplayAllWeapons()
    {
        //clear out list before displaying new contents
        weaponList.text = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Set up an object (Called "Command") to allow db control
            using (var command = connection.CreateCommand())
            {
                //Select what you want to get (in this case everything from the table weapons)
                //this just sets the parameters of what will be returned
                command.CommandText = "SELECT * FROM weapons ORDER BY name;";

                //iterate through the recordset that was returned from the statement above
                //just change what's inside the while statement
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //show to console that is in field "name" and in field "damage" for each row
                        //for reader ["XXXXXX"] - replace the XXXXXX with the field name you want to show
                        //this will display as many times as there are records returned
                        weaponList.text += reader["name"] + "\t\t\t\t" + reader["type"] + "\n";
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }

    //Displays all data of the entire table
    public void DisplayBowWeapons()
    {
        //clear out list before displaying new contents
        weaponList.text = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Set up an object (Called "Command") to allow db control
            using (var command = connection.CreateCommand())
            {
                //Select what you want to get (in this case everything from the table weapons)
                //this just sets the parameters of what will be returned
                command.CommandText = "SELECT * FROM weapons WHERE type LIKE '%Bow%';";

                //iterate through the recordset that was returned from the statement above
                //just change what's inside the while statement
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //show to console that is in field "name" and in field "damage" for each row
                        //for reader ["XXXXXX"] - replace the XXXXXX with the field name you want to show
                        //this will display as many times as there are records returned
                        weaponList.text += reader["name"] + "\t\t\t\t" + reader["type"] + "\n";
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }

    //Displays all data of the entire table
    public void DisplaySwordWeapons()
    {
        //clear out list before displaying new contents
        weaponList.text = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Set up an object (Called "Command") to allow db control
            using (var command = connection.CreateCommand())
            {
                //Select what you want to get (in this case everything from the table weapons)
                //this just sets the parameters of what will be returned
                command.CommandText = "SELECT * FROM weapons WHERE type LIKE '%Sword%';";

                //iterate through the recordset that was returned from the statement above
                //just change what's inside the while statement
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //show to console that is in field "name" and in field "damage" for each row
                        //for reader ["XXXXXX"] - replace the XXXXXX with the field name you want to show
                        //this will display as many times as there are records returned
                        weaponList.text += reader["name"] + "\t\t\t\t" + reader["type"] + "\n";
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }

    //Displays all data of the entire table
    public void DisplayLanceWeapons()
    {
        //clear out list before displaying new contents
        weaponList.text = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Set up an object (Called "Command") to allow db control
            using (var command = connection.CreateCommand())
            {
                //Select what you want to get (in this case everything from the table weapons)
                //this just sets the parameters of what will be returned
                command.CommandText = "SELECT * FROM weapons WHERE type LIKE '%Lance%';";

                //iterate through the recordset that was returned from the statement above
                //just change what's inside the while statement
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //show to console that is in field "name" and in field "damage" for each row
                        //for reader ["XXXXXX"] - replace the XXXXXX with the field name you want to show
                        //this will display as many times as there are records returned
                        weaponList.text += reader["name"] + "\t\t\t\t" + reader["type"] + "\n";
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }

    //Displays all data of the entire table
    public void DisplayHammerWeapons()
    {
        //clear out list before displaying new contents
        weaponList.text = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Set up an object (Called "Command") to allow db control
            using (var command = connection.CreateCommand())
            {
                //Select what you want to get (in this case everything from the table weapons)
                //this just sets the parameters of what will be returned
                command.CommandText = "SELECT * FROM weapons WHERE type LIKE '%Hammer%';";

                //iterate through the recordset that was returned from the statement above
                //just change what's inside the while statement
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //show to console that is in field "name" and in field "damage" for each row
                        //for reader ["XXXXXX"] - replace the XXXXXX with the field name you want to show
                        //this will display as many times as there are records returned
                        weaponList.text += reader["name"] + "\t\t\t\t" + reader["type"] + "\n";
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }
}
