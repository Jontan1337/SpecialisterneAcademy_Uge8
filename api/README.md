# Cereal API

An ASP.Net Core API that connects to a localhost database with a products table with information about different cereals brands.<br>
The goal of this project was to create a REST API to handle a dataset of different cereal brands with the use of CRUD operations, filtering and access privileges.<br>
The cereal data would have to be parsed from a CSV file by writing a script that could load the data and insert it into the database.<br>
Cereal data shown by the API should include a link to the corresponding picture included in the Cereal pictures.zip.

## Getting Started

### Quick setup
1. Start a MySQL database.
2. Import the cereal.sql into MySQL.
3. Start the Cereal API.
4. Open browser and go to http://localhost:5044/scalar/v1

### Alternative setup using the parser
1. Start a MySQL database.
2. Create a database called cereal.
3. Add a table called products.
4. Add each row to the table 

 | Name         | Type               | Null | Extra          |
 | ------------ | ------------------ | ---- | -------------- |
 | ID (PK)      | int                | No   | AUTO_INCREMENT |
 | Name         | varchar(1024)      | No   |                |
 | Manufacturer | varchar(1024)      | No   |                |
 | Type         | enum('COLD','HOT') | Yes  |                |
 | Calories     | int                | Yes  |                |
 | Protein      | int                | Yes  |                |
 | Fat          | int                | Yes  |                |
 | Sodium       | int                | Yes  |                |
 | Fiber        | float              | Yes  |                |
 | Carbo        | float              | Yes  |                |
 | Sugars       | int                | Yes  |                |
 | Potass       | int                | Yes  |                |
 | Vitamins     | int                | Yes  |                |
 | Shelf        | int                | Yes  |                |
 | Weight       | float              | Yes  |                |
 | Cups         | float              | Yes  |                |
 | Rating       | float              | Yes  |                |

2. Open Cereal_CSV_To_DB_Parser solution.
3. Open Program.cs and edit path to Cereal.csv file.
4. Run the Cereal parser script.
5. Start the Cereal API.
6. Open browser and go to http://localhost:5044/scalar/v1

## Endpoints
| Name                                 | Type   | Optional Parameters | About                                                                                                                                                     |
| ------------------------------------ | ------ | ------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| /login                               | POST   |                     | Login                                                                                                                                                     |
| /products                            | GET    | ?id=0               | Get products                                                                                                                                              |
| /product                             | POST   |                     | Create a new product                                                                                                                                      |
| /product                             | PUT    |                     | Update a product                                                                                                                                          |
| /product                             | PATCH  |                     | Update a product partially                                                                                                                                |
| /product/calories/{calories}         | GET    | ?option=less/more   | Get products by calories. Optional parameter string: less = products with fewer calories than specified/more = products with more calories than specified |
| /product/manufacturer/{manufacturer} | GET    |                     | Get all products by a manufacturer                                                                                                                        |
| /product/{id}                        | DELETE |                     | Delete a product by id                                                                                                                                    |

## Missing
- Privilege access.
- Link to cereal pictures.